namespace AzureDay.WebApp.Database.Entities
{
    public class TopicEntity
    {
        public int Id { get; set; }
        
        public string Title { get; set; }
        public string Abstract { get; set; }
        
        public string SpeakerId { get; set; }
    }
}