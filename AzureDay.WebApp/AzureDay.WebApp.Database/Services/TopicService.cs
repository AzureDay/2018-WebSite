using System.Linq;
using System.Collections.Generic;
using AzureDay.WebApp.Database.Entities;

namespace AzureDay.WebApp.Database.Services
{
    public class TopicService : BaseService<TopicEntity, int>
    {
        protected override List<TopicEntity> PopulateStorage()
        {
            return new List<TopicEntity>
            {
                new TopicEntity
                {
                    Id = -101,
                    Title = Localization.App.Service.Topics.Food.Registration.Title
                },
                new TopicEntity
                {
                    Id = -102,
                    Title = Localization.App.Service.Topics.Food.CoffeeBreak.Title
                },
                new TopicEntity
                {
                    Id = -103,
                    Title = Localization.App.Service.Topics.Food.Lunch.Title
                },
                new TopicEntity
                {
                    Id = -104,
                    Title = Localization.App.Service.Topics.Food.Afterparty.Title
                },
            };
        }

        public TopicEntity Registration { get { return Storage.Single(x => x.Id == -101); } }
        public TopicEntity CoffeeBreak { get { return Storage.Single(x => x.Id == -102); } }
        public TopicEntity Lunch { get { return Storage.Single(x => x.Id == -103); } }
        public TopicEntity Afterparty { get { return Storage.Single(x => x.Id == -104); } }
    }
}