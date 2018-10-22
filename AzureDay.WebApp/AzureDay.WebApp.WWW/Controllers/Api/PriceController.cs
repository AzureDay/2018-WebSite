using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AzureDay.WebApp.Database.Entities;
using AzureDay.WebApp.PaymentGateway.Core;
using AzureDay.WebApp.WWW.Infrastructure;
using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Mvc;
using TeamSpark.AzureDay.WebSite.Notification;
using TeamSpark.AzureDay.WebSite.Notification.Email.Model;

namespace AzureDay.WebApp.WWW.Controllers.Api
{
	public class PriceController : Controller
	{
		[HttpGet]
		[Route("api/tickets/price")]
		public async Task<decimal> GetTicketPrice(
			[FromQuery]bool conferenceTicket,
			[FromQuery]int workshopId,
			[FromQuery]string promoCode)
		{
			decimal ticketPrice = 0;

			if (conferenceTicket)
			{
				ticketPrice += Config.Configuration.TicketRegular;
			}

			if (workshopId > 0)
			{
				ticketPrice += Config.Configuration.TicketWorkshop;
			}

			var coupon = await AppFactory.CouponService.Value.GetValidCouponByCodeAsync(promoCode);

			ticketPrice = AppFactory.CouponService.Value.GetPriceWithCoupon(ticketPrice, coupon);

			return ticketPrice;
		}

		[HttpPost]
		[Route("api/tickets/paymentconfirm")]
		public async Task<string> PaymentConfirm([FromBody]PaymentResponse response)
		{
			var email = response.MerchantInternalUserId;
			var tickets = await AppFactory.TicketService.Value.GetTicketsByUserId(email);

			if (tickets != null && tickets.Any())
			{
				if (response.ErrorCode != 0)
				{
					var ai = new TelemetryClient();

					var props = new Dictionary<string, string>();
					props.Add("MerchantInternalPaymentId", response.MerchantInternalPaymentId);
					props.Add("MerchantInternalUserId", response.MerchantInternalUserId);
					props.Add("OrderId", response.OrderId.ToString());
					props.Add("ErrorCode", response.ErrorCode.ToString());
					props.Add("DebugMessage", response.DebugMessage);
					props.Add("Sum", response.Sum.ToString("F"));
					props.Add("OrderSum", response.OrderSum.ToString("F"));

					ai.TrackEvent("Payment error", props);

					var attendee = new Attendee
					{
						FirstName = User.GetFirstName(),
						LastName = User.GetLastName(),
						EMail = email
					};

					var message = new ErrorPaymentModel
					{
						Email = attendee.EMail,
						FullName = attendee.FullName
					};

					await Task.WhenAll(
						NotificationFactory.AttendeeNotificationService.Value.SendPaymentErrorEmailAsync(message)
					);
				}
				else
				{
					var attendee = new Attendee
					{
						FirstName = User.GetFirstName(),
						LastName = User.GetLastName(),
						EMail = email
					};

					var message = new ConfirmPaymentModel
					{
						Email = attendee.EMail,
						FullName = attendee.FullName
					};

					var orderSum = response.OrderSum;

					var tasks = new List<Task>();
					if ((decimal)tickets.Sum(x => x.Price) <= orderSum)
					{
						foreach (var ticket in tickets)
						{
							tasks.Add(AppFactory.TicketService.Value.SetTicketsPayedAsync(email, ticket.TicketType));
						}
						tasks.Add(NotificationFactory.AttendeeNotificationService.Value.SendPaymentConfirmationEmailAsync(message));
					}
					else
					{
						if (tickets.Count > 1)
						{
							if ((decimal)tickets[0].Price <= orderSum)
							{
								tasks.Add(AppFactory.TicketService.Value.SetTicketsPayedAsync(email, tickets[0].TicketType));
								tasks.Add(NotificationFactory.AttendeeNotificationService.Value.SendPaymentConfirmationEmailAsync(message));

								orderSum -= (decimal)tickets[0].Price;
							}

							if ((decimal)tickets[1].Price <= orderSum)
							{
								tasks.Add(AppFactory.TicketService.Value.SetTicketsPayedAsync(email, tickets[1].TicketType));
							}
							else
							{
								var newPrice = (decimal)tickets[1].Price - orderSum;
								tasks.Add(AppFactory.TicketService.Value.UpdateTicketPriceAsync(email, tickets[1].TicketType, newPrice));
							}
						}
						else
						{
							if ((decimal)tickets[0].Price <= orderSum)
							{
								tasks.Add(AppFactory.TicketService.Value.SetTicketsPayedAsync(email, tickets[0].TicketType));
								tasks.Add(NotificationFactory.AttendeeNotificationService.Value.SendPaymentConfirmationEmailAsync(message));
							}
						}
					}

					await Task.WhenAll(tasks);
				}
			}
			else
			{
				var ai = new TelemetryClient();

				var props = new Dictionary<string, string>();
				props.Add("MerchantInternalPaymentId", response.MerchantInternalPaymentId);
				props.Add("MerchantInternalUserId", response.MerchantInternalUserId);
				props.Add("OrderId", response.OrderId.ToString());
				props.Add("ErrorCode", response.ErrorCode.ToString());
				props.Add("DebugMessage", response.DebugMessage);
				props.Add("Sum", response.Sum.ToString("F"));
				props.Add("OrderSum", response.OrderSum.ToString("F"));

				ai.TrackEvent("Unable to find ticket", props);
			}

			return string.Empty;
		}
	}
}