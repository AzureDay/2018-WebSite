using System.Collections.Generic;
using AzureDay.WebApp.Database.Entities;

namespace AzureDay.WebApp.Database
{
    public class DbContext
    {
        public IEnumerable<RoomEntity> Rooms => new List<RoomEntity>
        {
            new RoomEntity { Id = 1, Name = "First" },
            new RoomEntity { Id = 2, Name = "Second" },
            new RoomEntity { Id = 3, Name = "Third" }
        };
        
        public IEnumerable<TimeSlotEntity> TimeSlots => new List<TimeSlotEntity>
        {
            
        };
        
        public IEnumerable<SessionEntity> Sessions => new List<SessionEntity>
        {
            
        };
        
        public IEnumerable<SpeakerEntity> Speakers => new List<SpeakerEntity>
        {
            
        };
        
        public IEnumerable<TopicEntity> Topics => new List<TopicEntity>
        {
            
        };
    }
}