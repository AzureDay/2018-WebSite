using System.Collections.Generic;
using AzureDay.WebApp.Database.Entities;

namespace AzureDay.WebApp.WWW.Models.Home
{
    public sealed class IndexModel
    {
        public SpeakersModel Speakers { get; set; }
        public List<PartnerEntity> Partners { get; set; }

        public IndexModel()
        {
            Speakers = new SpeakersModel();
            Partners = new List<PartnerEntity>();
        }
    }
}