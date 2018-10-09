using System.Linq;
using System.Collections.Generic;
using AzureDay.WebApp.Database.Entities;

namespace AzureDay.WebApp.Database.Services
{
    public sealed class CountryService : BaseService<CountryEntity, int>
    {
        protected override List<CountryEntity> PopulateStorage()
        {
            return new List<CountryEntity>
            {
                new CountryEntity {Id = 1, ImageUrl = "/images/flags/ua.png", Title = Localization.App.Service.Country.Ukraine}
            };
        }

        public CountryEntity Ukraine { get { return Storage.Single(x => x.Id == 1); } }
    }
}