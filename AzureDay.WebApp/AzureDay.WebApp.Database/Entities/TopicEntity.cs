namespace AzureDay.WebApp.Database.Entities
{
    public class TopicEntity: BaseEntity<int>
    {
        public string Title { get; set; }
        public string Abstract { get; set; }
        
        public string SpeakerId { get; set; }
    }
}