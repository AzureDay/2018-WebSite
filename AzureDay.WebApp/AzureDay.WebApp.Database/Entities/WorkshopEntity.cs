namespace AzureDay.WebApp.Database.Entities
{
    public class WorkshopEntity : BaseEntity<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public LanguageEntity Language { get; set; }
        public RoomEntity Room { get; set; }
        public int MaxTickets { get; set; }

        public SpeakerEntity Speaker { get; set; }

        public WorkshopEntity()
        {
            Language = new LanguageEntity();
            Room = new RoomEntity();
            Speaker = new SpeakerEntity();
        }
    }
}
