using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AzureDay.WebApp.Database.Enums;
using AzureDay.WebApp.Database.Services;
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
    }
}