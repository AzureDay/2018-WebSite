using AzureDay.WebApp.Database.Entities;

namespace AzureDay.WebApp.WWW.Models.Home
{
    public sealed class WorkshopModel
    {
        public WorkshopEntity Workshop { get; set; }
        public int TicketsLeft { get; set; }
        public bool ShowSpeakerInfo { get; set; }
    }
}
