using System;
using System.Collections.Generic;
using AzureDay.WebApp.Database.Entities;

namespace AzureDay.WebApp.Database.Services
{
    public sealed class SpeakerService : BaseService<SpeakerEntity, string>
    {
        private readonly List<SpeakerEntity> _speakers = new List<SpeakerEntity>();
        private readonly CountryService _countryService = new CountryService();

        protected override List<SpeakerEntity> PopulateStorage()
        {
            _speakers.Add(ABoyko());
            _speakers.Add(DIvanov());

            return _speakers;
        }

        public SpeakerEntity ABoyko()
        {
            return new SpeakerEntity
            {
                Id = "ABoyko",
                FirstName = Localization.App.Service.Speaker.ABoyko.FirstName,
                LastName = Localization.App.Service.Speaker.ABoyko.LastName,
                Bio = Localization.App.Service.Speaker.ABoyko.Bio.Replace(Environment.NewLine, "<br/>"),
                Country = _countryService.Ukraine,
                PhotoUrl = "/images/avatars/ABoyko.jpg",
                FacebookUrl = "https://www.facebook.com/boyko.ant",
                GitHubUrl = "",
                GoogleUrl = "",
                LinkedInUrl = "https://www.linkedin.com/in/boykoant/",
                MsdnUrl = "",
                MvpUrl = "https://mvp.microsoft.com/en-us/PublicProfile/5000824",
                TwitterUrl = "https://twitter.com/BoykoAnt",
                YouTubeUrl = "",
                WebUrl = "",
                CompanyName = "Ciklum",
                JobTitle = "Solution Architect"
            };
        }

        public SpeakerEntity DIvanov()
        {
            return new SpeakerEntity
            {
                Id = "DIvanov",
                FirstName = Localization.App.Service.Speaker.DIvanov.FirstName,
                LastName = Localization.App.Service.Speaker.DIvanov.LastName,
                Bio = Localization.App.Service.Speaker.DIvanov.Bio.Replace(Environment.NewLine, "<br/>"),
                Country = _countryService.Ukraine,
                PhotoUrl = "/images/avatars/DIvanov.jpg",
                FacebookUrl = "",
                GitHubUrl = "",
                GoogleUrl = "",
                LinkedInUrl = "",
                MsdnUrl = "",
                MvpUrl = "",
                TwitterUrl = "",
                YouTubeUrl = "",
                WebUrl = "",
                CompanyName = "Developex",
                JobTitle = "Developer"
            };
        }
    }
}