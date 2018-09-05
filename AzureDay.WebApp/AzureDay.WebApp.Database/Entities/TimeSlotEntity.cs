using System;

namespace AzureDay.WebApp.Database.Entities
{
    public class TimeSlotEntity
    {
        public int Id { get; set; }

        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}