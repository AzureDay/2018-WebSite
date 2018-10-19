using System.Linq;
using System.Collections.Generic;
using AzureDay.WebApp.Database.Entities;
using System;

namespace AzureDay.WebApp.Database.Services
{
    public class TopicService : BaseService<TopicEntity, int>
    {
        private readonly LanguageService _languageService = new LanguageService();
        private readonly SpeakerService _speakerService = new SpeakerService();

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
                new TopicEntity
                {
                    Id = 1,
                    Language = _languageService.Russian,
                    Speakers = new List<SpeakerEntity> {_speakerService.SBielskyi() },
                    Title = Localization.App.Service.Topics.SBielskyi_01.Title,
                    Description = Localization.App.Service.Topics.SBielskyi_01.Description.Replace(Environment.NewLine, "<br/>")
                },
                new TopicEntity
                {
                    Id = 2,
                    Language = _languageService.Russian,
                    Speakers = new List<SpeakerEntity> {_speakerService.ILeontiev() },
                    Title = Localization.App.Service.Topics.ILeontiev_01.Title,
                    Description = Localization.App.Service.Topics.ILeontiev_01.Description.Replace(Environment.NewLine, "<br/>")
                },
                new TopicEntity
                {
                    Id = 3,
                    Language = _languageService.English,
                    Speakers = new List<SpeakerEntity> {_speakerService.EAuberix() },
                    Title = Localization.App.Service.Topics.EAuberix_01.Title,
                    Description = Localization.App.Service.Topics.EAuberix_01.Description.Replace(Environment.NewLine, "<br/>")
                },
                new TopicEntity
                {
                    Id = 4,
                    Language = _languageService.Russian,
                    Speakers = new List<SpeakerEntity> {_speakerService.ABoyko() },
                    Title = Localization.App.Service.Topics.ABoyko_01.Title,
                    Description = Localization.App.Service.Topics.ABoyko_01.Description.Replace(Environment.NewLine, "<br/>")
                },
                new TopicEntity
                {
                    Id = 5,
                    Language = _languageService.Russian,
                    Speakers = new List<SpeakerEntity> {_speakerService.SLebedenko() },
                    Title = Localization.App.Service.Topics.SLebedenko_01.Title,
                    Description = Localization.App.Service.Topics.SLebedenko_01.Description.Replace(Environment.NewLine, "<br/>")
                },
                new TopicEntity
                {
                    Id = 6,
                    Language = _languageService.Russian,
                    Speakers = new List<SpeakerEntity> {_speakerService.ASurkov() },
                    Title = Localization.App.Service.Topics.ASurkov_01.Title,
                    Description = Localization.App.Service.Topics.ASurkov_01.Description.Replace(Environment.NewLine, "<br/>")
                },
                new TopicEntity
                {
                    Id = 7,
                    Language = _languageService.Russian,
                    Speakers = new List<SpeakerEntity> {_speakerService.SSultanov() },
                    Title = Localization.App.Service.Topics.SSultanov_01.Title,
                    Description = Localization.App.Service.Topics.SSultanov_01.Description.Replace(Environment.NewLine, "<br/>")
                },
                new TopicEntity
                {
                    Id = 8,
                    Language = _languageService.Russian,
                    Speakers = new List<SpeakerEntity> {_speakerService.EPolonychko() },
                    Title = Localization.App.Service.Topics.EPolonychko_01.Title,
                    Description = Localization.App.Service.Topics.EPolonychko_01.Description.Replace(Environment.NewLine, "<br/>")
                },
                new TopicEntity
                {
                    Id = 9,
                    Language = _languageService.Russian,
                    Speakers = new List<SpeakerEntity> {_speakerService.VTsykunov() },
                    Title = Localization.App.Service.Topics.VTsykunov_01.Title,
                    Description = Localization.App.Service.Topics.VTsykunov_01.Description.Replace(Environment.NewLine, "<br/>")
                },
            };
        }

        public TopicEntity Registration { get { return Storage.Single(x => x.Id == -101); } }
        public TopicEntity CoffeeBreak { get { return Storage.Single(x => x.Id == -102); } }
        public TopicEntity Lunch { get { return Storage.Single(x => x.Id == -103); } }
        public TopicEntity Afterparty { get { return Storage.Single(x => x.Id == -104); } }

        public TopicEntity SBielskyi_01 { get { return Storage.Single(x => x.Id == 1); } }
        public TopicEntity ILeontiev_01 { get { return Storage.Single(x => x.Id == 2); } }
        public TopicEntity EAuberix_01 { get { return Storage.Single(x => x.Id == 3); } }
        public TopicEntity ABoyko_01 { get { return Storage.Single(x => x.Id == 4); } }
        public TopicEntity SLebedenko_01 { get { return Storage.Single(x => x.Id == 5); } }
        public TopicEntity ASurkov_01 { get { return Storage.Single(x => x.Id == 6); } }
        public TopicEntity SSultanov_01 { get { return Storage.Single(x => x.Id == 7); } }
        public TopicEntity EPolonychko_01 { get { return Storage.Single(x => x.Id == 8); } }
        public TopicEntity VTsykunov_01 { get { return Storage.Single(x => x.Id == 9); } }
    }
}