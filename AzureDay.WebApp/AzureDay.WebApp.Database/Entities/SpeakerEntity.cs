namespace AzureDay.WebApp.Database.Entities
{
    public class SpeakerEntity: BaseEntity<string>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhotoUrl { get; set; }
    }
}