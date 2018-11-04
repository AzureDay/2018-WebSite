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
                    Id = 0,
                    Title = Localization.App.Service.Topics._Dummy.Title
                },
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
                    Id = -99,
                    Title = Localization.App.Service.Topics.Special.Keynote.Title
                },
                new TopicEntity
                {
                    Id = -98,
                    Title = Localization.App.Service.Topics.Special.Endnote.Title
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
                new TopicEntity
                {
                    Id = 10,
                    Language = _languageService.English,
                    Speakers = new List<SpeakerEntity> {_speakerService.EWasilewski() },
                    Title = Localization.App.Service.Topics.EWasilewski_01.Title,
                    Description = Localization.App.Service.Topics.EWasilewski_01.Description.Replace(Environment.NewLine, "<br/>")
                },
                new TopicEntity
                {
                    Id = 11,
                    Language = _languageService.Russian,
                    Speakers = new List<SpeakerEntity> {_speakerService.AVidishchev() },
                    Title = Localization.App.Service.Topics.AVidishchev_01.Title,
                    Description = Localization.App.Service.Topics.AVidishchev_01.Description.Replace(Environment.NewLine, "<br/>")
                },
                new TopicEntity
                {
                    Id = 12,
                    Language = _languageService.Russian,
                    Speakers = new List<SpeakerEntity> {_speakerService.VBezmaly() },
                    Title = Localization.App.Service.Topics.VBezmaly_01.Title,
                    Description = Localization.App.Service.Topics.VBezmaly_01.Description.Replace(Environment.NewLine, "<br/>")
                },
                new TopicEntity
                {
                    Id = 13,
                    Language = _languageService.Ukrainian,
                    Speakers = new List<SpeakerEntity> {_speakerService.OKrakovetskyi() },
                    Title = Localization.App.Service.Topics.OKrakovetskyi_02.Title,
                    Description = Localization.App.Service.Topics.OKrakovetskyi_02.Description.Replace(Environment.NewLine, "<br/>")
                },
                new TopicEntity
                {
                    Id = 14,
                    Language = _languageService.Russian,
                    Speakers = new List<SpeakerEntity> {_speakerService.SPoplavskiy() },
                    Title = Localization.App.Service.Topics.SPoplavskiy_02.Title,
                    Description = Localization.App.Service.Topics.SPoplavskiy_02.Description.Replace(Environment.NewLine, "<br/>")
                },
                new TopicEntity
                {
                    Id = 15,
                    Language = _languageService.Russian,
                    Speakers = new List<SpeakerEntity> {_speakerService.NDranchuk() },
                    Title = Localization.App.Service.Topics.NDranchuk_01.Title,
                    Description = Localization.App.Service.Topics.NDranchuk_01.Description.Replace(Environment.NewLine, "<br/>")
                },
                new TopicEntity
                {
                    Id = 16,
                    Language = _languageService.English,
                    Speakers = new List<SpeakerEntity> {_speakerService.KBaczyk() },
                    Title = Localization.App.Service.Topics.KBaczyk_01.Title,
                    Description = Localization.App.Service.Topics.KBaczyk_01.Description.Replace(Environment.NewLine, "<br/>")
                },
                new TopicEntity
                {
                    Id = 17,
                    Language = _languageService.Russian,
                    Speakers = new List<SpeakerEntity> {_speakerService.ILubenets() },
                    Title = Localization.App.Service.Topics.ILubenets_01.Title,
                    Description = Localization.App.Service.Topics.ILubenets_01.Description.Replace(Environment.NewLine, "<br/>")
                },
                new TopicEntity
                {
                    Id = 18,
                    Language = _languageService.Russian,
                    Speakers = new List<SpeakerEntity> {_speakerService.SKalinets() },
                    Title = Localization.App.Service.Topics.SKalinets_01.Title,
                    Description = Localization.App.Service.Topics.SKalinets_01.Description.Replace(Environment.NewLine, "<br/>")
                },
                new TopicEntity
                {
                    Id = 19,
                    Language = _languageService.Russian,
                    Speakers = new List<SpeakerEntity> {_speakerService.NMykhailenko() },
                    Title = Localization.App.Service.Topics.NMykhailenko_01.Title,
                    Description = Localization.App.Service.Topics.NMykhailenko_01.Description.Replace(Environment.NewLine, "<br/>")
                },
            };
        }

        public TopicEntity Dummy { get { return Storage.Single(x => x.Id == 0); } }
        
        public TopicEntity Registration { get { return Storage.Single(x => x.Id == -101); } }
        public TopicEntity CoffeeBreak { get { return Storage.Single(x => x.Id == -102); } }
        public TopicEntity Lunch { get { return Storage.Single(x => x.Id == -103); } }

        public TopicEntity Keynote { get { return Storage.Single(x => x.Id == -99); } }
        public TopicEntity Endnote { get { return Storage.Single(x => x.Id == -98); } }
        
        public TopicEntity SBielskyi_01 { get { return Storage.Single(x => x.Id == 1); } }
        public TopicEntity ILeontiev_01 { get { return Storage.Single(x => x.Id == 2); } }
        public TopicEntity EAuberix_01 { get { return Storage.Single(x => x.Id == 3); } }
        public TopicEntity ABoyko_01 { get { return Storage.Single(x => x.Id == 4); } }
        public TopicEntity SLebedenko_01 { get { return Storage.Single(x => x.Id == 5); } }
        public TopicEntity ASurkov_01 { get { return Storage.Single(x => x.Id == 6); } }
        public TopicEntity SSultanov_01 { get { return Storage.Single(x => x.Id == 7); } }
        public TopicEntity EPolonychko_01 { get { return Storage.Single(x => x.Id == 8); } }
        public TopicEntity VTsykunov_01 { get { return Storage.Single(x => x.Id == 9); } }
        public TopicEntity EWasilewski_01 { get { return Storage.Single(x => x.Id == 10); } }
        public TopicEntity AVidishchev_01 { get { return Storage.Single(x => x.Id == 11); } }
        public TopicEntity VBezmaly_01 { get { return Storage.Single(x => x.Id == 12); } }
        public TopicEntity OKrakovetskyi_02 { get { return Storage.Single(x => x.Id == 13); } } 
        public TopicEntity SPoplavskiy_02 { get { return Storage.Single(x => x.Id == 14); } }
        public TopicEntity NDranchuk_01 { get { return Storage.Single(x => x.Id == 15); } }
        public TopicEntity KBaczyk_01 { get { return Storage.Single(x => x.Id == 16); } }
        public TopicEntity ILubenets_01 { get { return Storage.Single(x => x.Id == 17); } }
        public TopicEntity SKalinets_01 { get { return Storage.Single(x => x.Id == 18); } }
        public TopicEntity NMykhailenko_01 { get { return Storage.Single(x => x.Id == 19); } }
    }
}