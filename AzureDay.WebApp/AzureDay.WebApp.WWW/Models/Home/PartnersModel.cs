using System.Collections.Generic;
using AzureDay.WebApp.Database.Entities;
using AzureDay.WebApp.Database.Enums;

namespace AzureDay.WebApp.WWW.Models.Home
{
    public sealed class PartnersModel
    {
        public Dictionary<PartnerType, List<PartnerEntity>> PartnersCollection { get; set; }
    }
}