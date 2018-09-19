namespace AzureDay.WebApp.Database.Entities
{
    public class TimetableEntity: BaseEntity<int>
    {
        public TopicEntity Topic { get; set; }
        public RoomEntity Room { get; set; }

        public int TimeStartHours { get; set; }
        public int TimeStartMinutes { get; set; }

        public int TimeEndHours { get; set; }
        public int TimeEndMinutes { get; set; }

        public string TimeStart
        {
            get => $"{TimeStartHours:D2}:{TimeStartMinutes:D2}";
            set
            {
                var parts = value.Split(':');
                TimeStartHours = int.Parse(parts[0]);
                TimeStartMinutes = int.Parse(parts[1]);
            }
        }

        public string TimeEnd
        {
            get => $"{TimeEndHours:D2}:{TimeEndMinutes:D2}";
            set
            {
                var parts = value.Split(':');
                TimeEndHours = int.Parse(parts[0]);
                TimeEndMinutes = int.Parse(parts[1]);
            }
        }

        public bool HasLanguage => !string.IsNullOrEmpty(Topic.Language?.Title);

        public TimetableEntity()
        {
            Topic = new TopicEntity();
            Room = new RoomEntity();
        }
    }
}