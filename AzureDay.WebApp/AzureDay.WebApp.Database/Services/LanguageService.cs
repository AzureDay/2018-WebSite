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
                new LanguageEntity { Id = "ua", Title = "Ukrainian", FlagUrl = "" },
                new LanguageEntity { Id = "en", Title = "English", FlagUrl = "" },
                new LanguageEntity { Id = "ru", Title = "Russian", FlagUrl = "" }
            };
        }
    }
}