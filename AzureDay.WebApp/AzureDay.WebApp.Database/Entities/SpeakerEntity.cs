using System.Collections.Generic;
using System.Text;

namespace AzureDay.WebApp.Database.Entities
{
    public class SpeakerEntity : BaseEntity<string>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public string PhotoUrl { get; set; }
        public string Bio { get; set; }
        public CountryEntity Country { get; set; }

        public string FacebookUrl { get; set; }
        public string LinkedInUrl { get; set; }
        public string GoogleUrl { get; set; }
        public string YouTubeUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string MsdnUrl { get; set; }
        public string MvpUrl { get; set; }
        public string GitHubUrl { get; set; }
        public string WebUrl { get; set; }

        public string CompanyName { get; set; }
        public string JobTitle { get; set; }

        public string Occupation
        {
            get
            {
                var ocupation = new StringBuilder(string.Empty);

                if (!string.IsNullOrEmpty(JobTitle))
                {
                    ocupation.Append(JobTitle);
                }

                if (!string.IsNullOrEmpty(JobTitle) && !string.IsNullOrEmpty(CompanyName))
                {
                    ocupation.Append(" @ ");
                }

                if (!string.IsNullOrEmpty(CompanyName))
                {
                    ocupation.Append(CompanyName);
                }

                return ocupation.ToString();
            }
        }

        public List<TopicEntity> Topics { get; set; }

        public SpeakerEntity()
        {
            Country = new CountryEntity();
            Topics = new List<TopicEntity>();
        }
    }
}