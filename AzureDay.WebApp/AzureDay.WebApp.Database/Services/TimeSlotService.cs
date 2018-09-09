using System;
using System.Collections.Generic;
using AzureDay.WebApp.Database.Entities;

namespace AzureDay.WebApp.Database.Services
{
    public class TimeSlotService: BaseService<TimeSlotEntity, int>
    {
        protected override List<TimeSlotEntity> PopulateStorage()
        {
            return new List<TimeSlotEntity>
            {
                new TimeSlotEntity { Id = 01, StartTime = new TimeSpan(09, 00, 0), EndTime = new TimeSpan(09, 30, 0) },   // registration
                new TimeSlotEntity { Id = 02, StartTime = new TimeSpan(09, 30, 0), EndTime = new TimeSpan(10, 00, 0) },   // opening
                new TimeSlotEntity { Id = 03, StartTime = new TimeSpan(10, 00, 0), EndTime = new TimeSpan(10, 15, 0) },   // break
                new TimeSlotEntity { Id = 04, StartTime = new TimeSpan(10, 15, 0), EndTime = new TimeSpan(11, 15, 0) },   // session 1
                new TimeSlotEntity { Id = 05, StartTime = new TimeSpan(11, 15, 0), EndTime = new TimeSpan(11, 45, 0) },   // lunch 1
                new TimeSlotEntity { Id = 06, StartTime = new TimeSpan(11, 45, 0), EndTime = new TimeSpan(12, 45, 0) },   // session 2
                new TimeSlotEntity { Id = 07, StartTime = new TimeSpan(12, 45, 0), EndTime = new TimeSpan(13, 00, 0) },   // break
                new TimeSlotEntity { Id = 08, StartTime = new TimeSpan(13, 00, 0), EndTime = new TimeSpan(14, 00, 0) },   // session 3
                new TimeSlotEntity { Id = 09, StartTime = new TimeSpan(14, 00, 0), EndTime = new TimeSpan(14, 30, 0) },   // lunch 2
                new TimeSlotEntity { Id = 10, StartTime = new TimeSpan(14, 30, 0), EndTime = new TimeSpan(15, 30, 0) },   // session 4
                new TimeSlotEntity { Id = 11, StartTime = new TimeSpan(15, 30, 0), EndTime = new TimeSpan(15, 45, 0) },   // break
                new TimeSlotEntity { Id = 12, StartTime = new TimeSpan(15, 45, 0), EndTime = new TimeSpan(16, 45, 0) },   // session 5
                new TimeSlotEntity { Id = 13, StartTime = new TimeSpan(16, 45, 0), EndTime = new TimeSpan(17, 15, 0) },   // lunch 3
                new TimeSlotEntity { Id = 14, StartTime = new TimeSpan(17, 15, 0), EndTime = new TimeSpan(18, 15, 0) },   // session 6
                new TimeSlotEntity { Id = 15, StartTime = new TimeSpan(18, 15, 0), EndTime = new TimeSpan(19, 00, 0) }    // raffle
            };
        }
    }
}