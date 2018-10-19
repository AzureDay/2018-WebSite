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
                new CountryEntity {Id = 1, ImageUrl = "/images/flags/ua.png", Title = Localization.App.Service.Country.Ukraine},
                new CountryEntity {Id = 2, ImageUrl = "/images/flags/ru.png", Title = Localization.App.Service.Country.Russia},
                new CountryEntity {Id = 4, ImageUrl = "/images/flags/fr.png", Title = Localization.App.Service.Country.France},
                new CountryEntity {Id = 6, ImageUrl = "/images/flags/pl.png", Title = Localization.App.Service.Country.Poland},
            };
        }

        public CountryEntity Ukraine { get { return Storage.Single(x => x.Id == 1); } }
        public CountryEntity Russia { get { return Storage.Single(x => x.Id == 2); } }
        public CountryEntity France { get { return Storage.Single(x => x.Id == 4); } }
        public CountryEntity Poland { get { return Storage.Single(x => x.Id == 6); } }
    }
}