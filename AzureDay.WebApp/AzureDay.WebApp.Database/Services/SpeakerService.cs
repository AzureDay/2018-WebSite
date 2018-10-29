using System;
using System.Collections.Generic;
using System.Linq;
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
            _speakers.Add(ILeontiev());
            _speakers.Add(VTsykunov());
            _speakers.Add(SBielskyi());
            _speakers.Add(EAuberix());
            _speakers.Add(SLebedenko());
            _speakers.Add(ASurkov());
            _speakers.Add(SSultanov());
            _speakers.Add(EPolonychko()); 
            _speakers.Add(EWasilewski());
            _speakers.Add(AVidishchev());
            _speakers.Add(VBezmaly());
            _speakers.Add(OKrakovetskyi());

            return _speakers;
        }

        public override IEnumerable<SpeakerEntity> GetAll()
        {
            return base.GetAll().OrderBy(x => x.FullName);
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

        public SpeakerEntity ILeontiev()
        {
            return new SpeakerEntity
            {
                Id = "ILeontiev",
                FirstName = Localization.App.Service.Speaker.ILeontiev.FirstName,
                LastName = Localization.App.Service.Speaker.ILeontiev.LastName,
                Bio = Localization.App.Service.Speaker.ILeontiev.Bio.Replace(Environment.NewLine, "<br/>"),
                Country = _countryService.Ukraine,
                PhotoUrl = "/images/avatars/ILeontyev.jpg",
                FacebookUrl = "",
                GitHubUrl = "",
                GoogleUrl = "",
                LinkedInUrl = "https://www.linkedin.com/in/leontievihor/",
                MsdnUrl = "",
                MvpUrl = "",
                TwitterUrl = "",
                YouTubeUrl = "",
                WebUrl = "",
                CompanyName = "Lead Architect",
                JobTitle = "Viseo group"
            };
        }

        public SpeakerEntity VTsykunov()
        {
            return new SpeakerEntity
            {
                Id = "VTsykunov",
                FirstName = Localization.App.Service.Speaker.VTsykunov.FirstName,
                LastName = Localization.App.Service.Speaker.VTsykunov.LastName,
                Bio = Localization.App.Service.Speaker.VTsykunov.Bio.Replace(Environment.NewLine, "<br/>"),
                Country = _countryService.Ukraine,
                PhotoUrl = "/images/avatars/VTsykunov.jpg",
                FacebookUrl = "https://www.facebook.com/vtsykunov",
                GitHubUrl = "",
                GoogleUrl = "",
                LinkedInUrl = "",
                MsdnUrl = "",
                MvpUrl = "",
                TwitterUrl = "",
                YouTubeUrl = "",
                WebUrl = "",
                CompanyName = "",
                JobTitle = ""
            };
        }

        public SpeakerEntity SBielskyi()
        {
            return new SpeakerEntity
            {
                Id = "SBielskyi",
                FirstName = Localization.App.Service.Speaker.SBielskyi.FirstName,
                LastName = Localization.App.Service.Speaker.SBielskyi.LastName,
                Bio = Localization.App.Service.Speaker.SBielskyi.Bio.Replace(Environment.NewLine, "<br/>"),
                Country = _countryService.Ukraine,
                PhotoUrl = "/images/avatars/SergiiBielskyi.jpg",
                FacebookUrl = "",
                GitHubUrl = "",
                GoogleUrl = "",
                LinkedInUrl = "",
                MsdnUrl = "",
                MvpUrl = "",
                TwitterUrl = "",
                YouTubeUrl = "",
                WebUrl = "",
                CompanyName = "",
                JobTitle = ""
            };
        }

        public SpeakerEntity EAuberix()
        {
            return new SpeakerEntity
            {
                Id = "EAuberix",
                FirstName = Localization.App.Service.Speaker.EAuberix.FirstName,
                LastName = Localization.App.Service.Speaker.EAuberix.LastName,
                Bio = Localization.App.Service.Speaker.EAuberix.Bio.Replace(Environment.NewLine, "<br/>"),
                Country = _countryService.France,
                PhotoUrl = "/images/avatars/EAuberix.jpg",
                FacebookUrl = "",
                GitHubUrl = "",
                GoogleUrl = "",
                LinkedInUrl = "",
                MsdnUrl = "",
                MvpUrl = "",
                TwitterUrl = "https://twitter.com/FollowEstelle",
                YouTubeUrl = "",
                WebUrl = "",
                CompanyName = "",
                JobTitle = ""
            };
        }

        public SpeakerEntity SLebedenko()
        {
            return new SpeakerEntity
            {
                Id = "SLebedenko",
                FirstName = Localization.App.Service.Speaker.SLebedenko.FirstName,
                LastName = Localization.App.Service.Speaker.SLebedenko.LastName,
                Bio = Localization.App.Service.Speaker.SLebedenko.Bio.Replace(Environment.NewLine, "<br/>"),
                Country = _countryService.Ukraine,
                PhotoUrl = "/images/avatars/LebedenkoStas.jpg",
                FacebookUrl = "",
                GitHubUrl = "",
                GoogleUrl = "",
                LinkedInUrl = "",
                MsdnUrl = "",
                MvpUrl = "",
                TwitterUrl = "",
                YouTubeUrl = "",
                WebUrl = "",
                CompanyName = "Sigma Software",
                JobTitle = ""
            };
        }

        public SpeakerEntity ASurkov()
        {
            return new SpeakerEntity
            {
                Id = "ASurkov",
                FirstName = Localization.App.Service.Speaker.ASurkov.FirstName,
                LastName = Localization.App.Service.Speaker.ASurkov.LastName,
                Bio = Localization.App.Service.Speaker.ASurkov.Bio.Replace(Environment.NewLine, "<br/>"),
                Country = _countryService.Russia,
                PhotoUrl = "/images/avatars/ASurkov.jpg",
                FacebookUrl = "https://www.facebook.com/AOSurkov",
                GitHubUrl = "",
                GoogleUrl = "",
                LinkedInUrl = "",
                MsdnUrl = "",
                MvpUrl = "https://mvp.microsoft.com/ru-ru/PublicProfile/5002197",
                TwitterUrl = "https://twitter.com/AOSurkov",
                YouTubeUrl = "",
                WebUrl = "",
                CompanyName = "",
                JobTitle = ""
            };
        }

        public SpeakerEntity SSultanov()
        {
            return new SpeakerEntity
            {
                Id = "SSultanov",
                FirstName = Localization.App.Service.Speaker.SSultanov.FirstName,
                LastName = Localization.App.Service.Speaker.SSultanov.LastName,
                Bio = Localization.App.Service.Speaker.SSultanov.Bio.Replace(Environment.NewLine, "<br/>"),
                Country = _countryService.Ukraine,
                PhotoUrl = "/images/avatars/StasSultanov.jpg",
                FacebookUrl = "",
                GitHubUrl = "",
                GoogleUrl = "",
                LinkedInUrl = "",
                MsdnUrl = "",
                MvpUrl = "",
                TwitterUrl = "",
                YouTubeUrl = "",
                WebUrl = "",
                CompanyName = "",
                JobTitle = ""
            };
        }

        public SpeakerEntity EPolonychko()
        {
            return new SpeakerEntity
            {
                Id = "EPolonychko",
                FirstName = Localization.App.Service.Speaker.EPolonychko.FirstName,
                LastName = Localization.App.Service.Speaker.EPolonychko.LastName,
                Bio = Localization.App.Service.Speaker.EPolonychko.Bio.Replace(Environment.NewLine, "<br/>"),
                Country = _countryService.Ukraine,
                PhotoUrl = "/images/avatars/EPolonychko.jpg",
                FacebookUrl = "https://www.facebook.com/mydjeki",
                GitHubUrl = "",
                GoogleUrl = "",
                LinkedInUrl = "",
                MsdnUrl = "",
                MvpUrl = "",
                TwitterUrl = "",
                YouTubeUrl = "",
                WebUrl = "",
                CompanyName = "",
                JobTitle = ""
            };
        }
     
        public SpeakerEntity EWasilewski()
        {
            return new SpeakerEntity
            {
                Id = "EWasilewski",
                FirstName = Localization.App.Service.Speaker.EWasilewski.FirstName,
                LastName = Localization.App.Service.Speaker.EWasilewski.LastName,
                Bio = Localization.App.Service.Speaker.EWasilewski.Bio.Replace(Environment.NewLine, "<br/>"),
                Country = _countryService.Poland,
                PhotoUrl = "/images/avatars/EmilWasilewski.jpg",
                FacebookUrl = "",
                GitHubUrl = "",
                GoogleUrl = "",
                LinkedInUrl = "http://www.linkedin.com/in/emilwasilewski",
                MsdnUrl = "",
                MvpUrl = "",
                TwitterUrl = "https://twitter.com/WasilewskiEmil",
                YouTubeUrl = "",
                WebUrl = "",
                CompanyName = "Bystronic Group",
                JobTitle = "Senior Azure Infrastructure Architect"
            };
        }

        public SpeakerEntity AVidishchev()
        {
            return new SpeakerEntity
            {
                Id = "AVidishchev",
                FirstName = Localization.App.Service.Speaker.AVidishchev.FirstName,
                LastName = Localization.App.Service.Speaker.AVidishchev.LastName,
                Bio = Localization.App.Service.Speaker.AVidishchev.Bio.Replace(Environment.NewLine, "<br/>"),
                Country = _countryService.Ukraine,
                PhotoUrl = "/images/avatars/AVidishchev.jpg",
                FacebookUrl = "https://www.facebook.com/anton.vidishchev",
                GitHubUrl = "",
                GoogleUrl = "",
                LinkedInUrl = "https://www.linkedin.com/in/antonvidishchev",
                MsdnUrl = "",
                MvpUrl = "",
                TwitterUrl = "",
                YouTubeUrl = "",
                WebUrl = "",
                CompanyName = "SoftServe",
                JobTitle = "Azure Architect"
            };
        }

        public SpeakerEntity VBezmaly()
        {
            return new SpeakerEntity
            {
                Id = "VBezmaly",
                FirstName = Localization.App.Service.Speaker.VBezmaly.FirstName,
                LastName = Localization.App.Service.Speaker.VBezmaly.LastName,
                Bio = Localization.App.Service.Speaker.VBezmaly.Bio.Replace(Environment.NewLine, "<br/>"),
                Country = _countryService.Ukraine,
                PhotoUrl = "/images/avatars/VBezmaly.jpg",
                FacebookUrl = "https://www.facebook.com/vlad.bezmaly",
                GitHubUrl = "",
                GoogleUrl = "",
                LinkedInUrl = "",
                MsdnUrl = "",
                MvpUrl = "",
                TwitterUrl = "",
                YouTubeUrl = "",
                WebUrl = "",
                CompanyName = "Kaspersky Lab",
                JobTitle = "Kaspersky Certified Trainer"
            };
        }

        public SpeakerEntity OKrakovetskyi()
        {
            return new SpeakerEntity
            {
                Id = "OKrakovetskyi",
                FirstName = Localization.App.Service.Speaker.OKrakovetskyi.FirstName,
                LastName = Localization.App.Service.Speaker.OKrakovetskyi.LastName,
                Bio = Localization.App.Service.Speaker.OKrakovetskyi.Bio.Replace(Environment.NewLine, "<br/>"),
                Country = _countryService.Ukraine,
                PhotoUrl = "/images/avatars/OKrakovetskyi.jpg",
                FacebookUrl = "https://www.facebook.com/alex.krakovetskiy",
                GitHubUrl = "",
                GoogleUrl = "",
                LinkedInUrl = "https://www.linkedin.com/in/krakovetskiy/",
                MsdnUrl = "",
                MvpUrl = "",
                TwitterUrl = "https://twitter.com/msugvnua",
                YouTubeUrl = "",
                WebUrl = "",
                CompanyName = "DevRain Solutions",
                JobTitle = "CEO"
            };
        }
    }
}