using AzureDay.WebApp.Database.Enums;

namespace AzureDay.WebApp.Database.Entities
{
    public class PartnerEntity : BaseEntity<string>
    {
        public string Title { get; set; }
        public string LogoUrl { get; set; }
        public string WebUrl { get; set; }
        public string Description { get; set; }
        public PartnerType PartnerType { get; set; }
    }
}