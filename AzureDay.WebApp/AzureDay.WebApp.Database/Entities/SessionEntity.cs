namespace AzureDay.WebApp.Database.Entities
{
    public class SessionEntity
    {
        public int Id { get; set; }

        public int RoomId { get; set; }
        public int TopicId { get; set; }
        public int TimeSlotEntityId { get; set; }
    }
}