using System;

namespace AzureDay.WebApp.Database.Entities
{
    public class TimeSlotEntity: BaseEntity<int>
    {
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}