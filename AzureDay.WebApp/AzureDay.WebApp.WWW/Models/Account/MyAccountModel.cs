using System.Collections.Generic;
using AzureDay.WebApp.Database.Entities;
using AzureDay.WebApp.WWW.Models.Home;

namespace AzureDay.WebApp.WWW.Models.Account
{
    public class MyAccountModel
    {
        public List<WorkshopModel> Workshops { get; set; }
        public Ticket PayedConferenceTicket { get; set; }
        public Ticket PayedWorkshopTicket { get; set; }
        public WorkshopEntity PayedWorkshop { get; set; }
    }
}