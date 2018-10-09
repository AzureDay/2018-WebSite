using System;
using System.Linq;
using System.Collections.Generic;
using AzureDay.WebApp.Database.Entities;
using AzureDay.WebApp.Database.Enums;

namespace AzureDay.WebApp.Database.Services
{
    public sealed class PartnerService : BaseService<PartnerEntity, string>
    {
        protected override List<PartnerEntity> PopulateStorage()
        {
            return new List<PartnerEntity>
            {
                new PartnerEntity
                {
                    Id = "Microsoft",
                    Title = Localization.App.Service.Partners.Microsoft.Title,
                    Description = Localization.App.Service.Partners.Microsoft.Description.Replace(Environment.NewLine, "<br/>"),
                    LogoUrl = "/images/logos/microsoft.jpg",
                    WebUrl = "https://www.microsoft.com/uk-ua/",
                    PartnerType = PartnerType.Info | PartnerType.Gold | PartnerType.Workshop
                }
            };
        }

        public IEnumerable<PartnerEntity> GetPartnersByType(PartnerType partnerType)
        {
            return Storage
                .Where(x => x.PartnerType.HasFlag(partnerType))
                .OrderBy(x => x.Id);
        }
    }
}