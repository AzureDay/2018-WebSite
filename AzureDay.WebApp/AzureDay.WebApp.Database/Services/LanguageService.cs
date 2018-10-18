using System.Linq;
using System.Collections.Generic;
using AzureDay.WebApp.Database.Entities;

namespace AzureDay.WebApp.Database.Services
{
    public class LanguageService: BaseService<LanguageEntity, string>
    {
        protected override List<LanguageEntity> PopulateStorage()
        {
            return new List<LanguageEntity>
            {
                new LanguageEntity { Id = "ua", Title = Localization.App.Service.Language.Ukrainian, FlagUrl = "/images/flags/ua.png" },
                new LanguageEntity { Id = "en", Title = Localization.App.Service.Language.English, FlagUrl = "" },
                new LanguageEntity { Id = "ru", Title = Localization.App.Service.Language.Russian, FlagUrl = "/images/flags/ru.png" }
            };
        }

        public LanguageEntity Ukrainian { get { return Storage.Single(x => x.Id == "ua"); } }
        public LanguageEntity Russian { get { return Storage.Single(x => x.Id == "ru"); } }
        public LanguageEntity English { get { return Storage.Single(x => x.Id == "en"); } }
    }
}