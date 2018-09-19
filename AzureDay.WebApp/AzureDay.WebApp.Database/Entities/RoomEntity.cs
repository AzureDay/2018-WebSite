using AzureDay.WebApp.Database.Enums;

namespace AzureDay.WebApp.Database.Entities
{
    public class RoomEntity: BaseEntity<int>
    {
        public string Title { get; set; }
        public RoomType RoomType { get; set; }

        public int ColorNumber { get; set; }
    }
}