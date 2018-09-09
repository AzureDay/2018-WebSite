namespace AzureDay.WebApp.Database.Entities
{
    public class SessionEntity: BaseEntity<int>
    {
        public int RoomId { get; set; }
        public int TopicId { get; set; }
        public int TimeSlotEntityId { get; set; }
    }
}