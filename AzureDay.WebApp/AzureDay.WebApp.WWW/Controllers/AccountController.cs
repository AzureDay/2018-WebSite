using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AzureDay.WebApp.Config;
using AzureDay.WebApp.Database.Entities;
using AzureDay.WebApp.Database.Enums;
using AzureDay.WebApp.Database.Services;
using AzureDay.WebApp.PaymentGateway.Core;
using AzureDay.WebApp.WWW.Infrastructure;
using AzureDay.WebApp.WWW.Models.Account;
using AzureDay.WebApp.WWW.Models.Home;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AzureDay.WebApp.WWW.Controllers
{
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly AzureAdB2COptions _options;
        private readonly Lazy<WorkshopService> _workshopService = new Lazy<WorkshopService>(() => new WorkshopService());

        public AccountController(IOptions<AzureAdB2COptions> b2cOptions)
        {
            _options = b2cOptions.Value;
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            var redirectUrl = Url.Action(nameof(HomeController.Index), "Home");
            return Challenge(
                new AuthenticationProperties {RedirectUri = redirectUrl},
                OpenIdConnectDefaults.AuthenticationScheme);
        }

        [HttpGet]
        public IActionResult ResetPassword()
        {
            var redirectUrl = Url.Action(nameof(HomeController.Index), "Home");
            var properties = new AuthenticationProperties {RedirectUri = redirectUrl};
            properties.Items[AzureAdB2COptions.PolicyAuthenticationProperty] = _options.ResetPasswordPolicyId;
            return Challenge(properties, OpenIdConnectDefaults.AuthenticationScheme);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Profile()
        {
            var ticketsTask = AppFactory.TicketService.Value.GetTicketsByEmailAsync(User.GetEmail());
            var workshopTicketsTask = AppFactory.TicketService.Value.GetWorkshopsTicketsAsync();

            await Task.WhenAll(ticketsTask, workshopTicketsTask);

            var model = new MyAccountModel();

            var workshops = _workshopService.Value.GetAll().ToList();

            model.Workshops = new List<WorkshopModel>();

            var workshopTickets = workshopTicketsTask.Result;

            foreach (var workshop in workshops)
            {
                var ticketsLeft = workshop.MaxTickets - workshopTickets.Count(x => x.WorkshopId == workshop.Id);
                if (ticketsLeft < 0)
                {
                    ticketsLeft = 0;
                }

                if (ticketsLeft > 0)
                {
                    model.Workshops.Add(new WorkshopModel
                    {
                        Workshop = workshop,
                        TicketsLeft = ticketsLeft
                    });
                }
            }

            var tickets = ticketsTask.Result;

            if (tickets != null && tickets.Any())
            {
                model.PayedConferenceTicket = tickets.SingleOrDefault(x => x.TicketType == TicketType.Regular);

                model.PayedWorkshopTicket = tickets.SingleOrDefault(x => x.TicketType == TicketType.Workshop);
                if (model.PayedWorkshopTicket != null)
                {
                    model.PayedWorkshop = _workshopService.Value.GetById(model.PayedWorkshopTicket.WorkshopId.Value);
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult EditProfile()
        {
            var redirectUrl = Url.Action(nameof(HomeController.Index), "Home");
            var properties = new AuthenticationProperties {RedirectUri = redirectUrl};
            properties.Items[AzureAdB2COptions.PolicyAuthenticationProperty] = _options.EditProfilePolicyId;
            return Challenge(properties, OpenIdConnectDefaults.AuthenticationScheme);
        }

        [HttpGet]
        public IActionResult SignOut()
        {
            var callbackUrl = Url.Action(nameof(SignedOut), "Account", values: null, protocol: Request.Scheme);
            return SignOut(new AuthenticationProperties {RedirectUri = callbackUrl},
                CookieAuthenticationDefaults.AuthenticationScheme, OpenIdConnectDefaults.AuthenticationScheme);
        }

        [HttpGet]
        public IActionResult SignedOut()
        {
            if (User.Identity.IsAuthenticated)
            {
                // Redirect to home page if the user is authenticated.
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            return View();
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
        
        private PayFormModel GetPaymentForm(List<Ticket> tickets)
		{
			if (tickets == null)
			{
				throw new ArgumentNullException(nameof(tickets));
			}

			if (!tickets.Any())
			{
				throw new ArgumentException(nameof(tickets));
			}

			KaznacheyPaymentSystem kaznachey;
			int paySystemId;
			if (string.IsNullOrEmpty(tickets[0].PaymentType))
			{
				kaznachey = new KaznacheyPaymentSystem(Configuration.KaznacheyMerchantId, Configuration.KaznacheyMerchantSecreet);
				paySystemId = kaznachey.GetMerchantInformation().PaySystems[0].Id;
			}
			else
			{
				switch (tickets[0].PaymentType.ToLowerInvariant())
				{
					case "kaznachey":
						kaznachey = new KaznacheyPaymentSystem(Configuration.KaznacheyMerchantId, Configuration.KaznacheyMerchantSecreet);
						paySystemId = kaznachey.GetMerchantInformation().PaySystems[0].Id;
						break;
					case "liqpay":
						kaznachey = new KaznacheyPaymentSystem(Configuration.KaznacheyMerchantId, Configuration.KaznacheyMerchantSecreet);
						paySystemId = 1021;
						break;
					default:
						kaznachey = new KaznacheyPaymentSystem(Configuration.KaznacheyMerchantId, Configuration.KaznacheyMerchantSecreet);
						paySystemId = kaznachey.GetMerchantInformation().PaySystems[0].Id;
						break;
				}
			}

			var paymentRequest = new PaymentRequest(paySystemId);
			paymentRequest.Language = "RU";
			paymentRequest.Currency = "UAH";
			paymentRequest.PaymentDetail = new PaymentDetails
			{
				EMail = tickets[0].Attendee.EMail,
				MerchantInternalUserId = tickets[0].Attendee.EMail,
				MerchantInternalPaymentId = $"{tickets[0].Attendee.EMail}-{string.Join("-", tickets.Select(x => x.TicketType.ToString()))}",
				BuyerFirstname = tickets[0].Attendee.FirstName,
				BuyerLastname = tickets[0].Attendee.LastName,
				ReturnUrl = $"{Configuration.Host}/account/profile",
				StatusUrl = $"{Configuration.Host}/api/tickets/paymentconfirm"
			};
			paymentRequest.Products = new List<Product>
			{
				new Product
				{
					ProductId = string.Join("-", tickets.Select(x => x.TicketType.ToString())),
					ProductItemsNum = 1,
					ProductName = $"{tickets[0].Attendee.FirstName} {tickets[0].Attendee.LastName} билет на AzureDay {Configuration.Year} ({string.Join("-", tickets.Select(x => x.TicketType.ToString()))})",
					ProductPrice = (decimal) tickets.Sum(x => x.Price)
				}
			};

			var form = kaznachey.CreatePayment(paymentRequest).ExternalFormHtml;

			var model = new PayFormModel
			{
				Form = form
			};
			return model;
		}

		[Authorize]
		[HttpPost]
		[Consumes("application/x-www-form-urlencoded")]
		public async Task<ActionResult> Pay([FromForm]PayModel model)
		{
			if (!model.HasConferenceTicket && (!model.HasWorkshopTicket || model.DdlWorkshop == 0))
			{
				throw new ArgumentException(nameof(model));
			}

			var tickets = new List<Ticket>();

			if (model.HasConferenceTicket)
			{
				tickets.Add(new Ticket
				{
					TicketType = TicketType.Regular,
					PaymentType = model.PaymentType,
					Price = (double)AppFactory.TicketService.Value.GetTicketPrice(TicketType.Regular)
				});
			}

			if (model.HasWorkshopTicket && model.DdlWorkshop > 0)
			{
				tickets.Add(new Ticket
				{
					TicketType = TicketType.Workshop,
					PaymentType = model.PaymentType,
					WorkshopId = model.DdlWorkshop,
					Price = (double)AppFactory.TicketService.Value.GetTicketPrice(TicketType.Workshop)
				});
			}

			if (!tickets.Any())
			{
				throw new ArgumentException(nameof(model));
			}

			var coupon = await AppFactory.CouponService.Value.GetValidCouponByCodeAsync(model.PromoCode);

			decimal ticketTotalPrice = tickets.Count > 1 ?
				AppFactory.TicketService.Value.GetTicketPrice(TicketType.Regular | TicketType.Workshop) :
				AppFactory.TicketService.Value.GetTicketPrice(tickets[0].TicketType);
			ticketTotalPrice = AppFactory.CouponService.Value.GetPriceWithCoupon(ticketTotalPrice, coupon);

			await AppFactory.CouponService.Value.UseCouponByCodeAsync(model.PromoCode);

			if (tickets.Count > 1)
			{
				tickets[0].Price = (double)ticketTotalPrice / 2;
				tickets[0].Coupon = coupon;
				tickets[0].IsPayed = tickets[0].Price <= 0;

				tickets[1].Price = (double)ticketTotalPrice / 2;
				tickets[1].Coupon = coupon;
				tickets[1].IsPayed = tickets[1].Price <= 0;
			}
			else
			{
				tickets[0].Price = (double) ticketTotalPrice;
				tickets[0].Coupon = coupon;
				tickets[0].IsPayed = tickets[0].Price <= 0;
			}

			var isPayed = true;

			foreach (var ticket in tickets)
			{
				if (ticket.Attendee == null)
				{
					var email = User.GetEmail();
					ticket.Attendee = new Attendee
					{
						FirstName = User.GetFirstName(),
						LastName = User.GetLastName(),
						EMail = email
					};
					ticket.AttendeeEmail = email;
				}

				await AppFactory.TicketService.Value.AddTicketAsync(ticket);

				isPayed = isPayed && ticket.IsPayed;
			}

			if (isPayed)
			{
				return RedirectToAction("Profile");
			}
			else
			{
				var payForm = GetPaymentForm(tickets);

				return View("PayForm", payForm);
			}
		}

		[Authorize]
		public async Task<ActionResult> PayAgain()
		{
			var email = User.GetEmail();

			var attendee = new Attendee
			{
				FirstName = User.GetFirstName(),
				LastName = User.GetLastName(),
				EMail = email
			};
			var tickets = await AppFactory.TicketService.Value.GetTicketsByEmailAsync(email);

			foreach (var ticket in tickets)
			{
				ticket.Attendee = attendee;
			}

			var model = GetPaymentForm(tickets);

			return View("PayForm", model);
		}

		[Authorize]
		public async Task<ActionResult> DeleteTicket(string token)
		{
			var email = User.GetEmail();
			TicketType ticketType;
			if (!Enum.TryParse(token, true, out ticketType))
			{
				throw new ArgumentException();
			}

			var tickets = await AppFactory.TicketService.Value.GetTicketsByEmailAsync(email);
			var ticketToDelete = tickets.Single(x => x.TicketType == ticketType);
			var ticketToRemain = tickets.SingleOrDefault(x => x.TicketType != ticketType);

			var couponCode = ticketToDelete.Coupon == null ?
				string.Empty :
				ticketToDelete.Coupon.Code;

			var tasks = new List<Task>
			{
				AppFactory.TicketService.Value.DeleteTicketAsync(email, ticketToDelete.TicketType)
			};

			if (ticketToRemain == null)
			{
				tasks.Add(AppFactory.CouponService.Value.RestoreCouponByCodeAsync(couponCode));
			}
			else
			{
				var price = AppFactory.TicketService.Value.GetTicketPrice(ticketToRemain.TicketType);

				if (ticketToRemain.Coupon != null)
				{
					price = AppFactory.CouponService.Value.GetPriceWithCoupon(price, ticketToRemain.Coupon);
				}

				tasks.Add(AppFactory.TicketService.Value.UpdateTicketPriceAsync(email, ticketToRemain.TicketType, price));
			}

			await Task.WhenAll(tasks);

			return RedirectToAction("Profile");
		}

/*		[Authorize]
		public async Task<ActionResult> PersonalSchedule()
		{
			var model = new ScheduleModel();

			model.Rooms = _roomService.Value
				.GetRooms()
				.Where(x => x.RoomType == RoomType.LectureRoom)
				.ToList();

			model.Timetables = _timetableService.Value.GetTimetable()
				.GroupBy(
					t => t.TimeStart,
					(key, timetables) => timetables.OrderBy(t => t.Room.ColorNumber).ToList())
				.ToList();

			return View(model);
		}*/
    }
}