using System.Collections.Generic;
using AzureDay.WebApp.Database.Entities;

namespace AzureDay.WebApp.Database.Services
{
    public class TimetableService: BaseService<TimetableEntity, int>
    {
        protected override List<TimetableEntity> PopulateStorage()
        {
            throw new System.NotImplementedException();
        }
    }
}