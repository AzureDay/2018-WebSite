using System.Collections.Generic;
using AzureDay.WebApp.Database.Entities;

namespace AzureDay.WebApp.WWW.Models.Home
{
    public class ScheduleModel
    {
        public List<RoomEntity> Rooms { get; set; }

        public List<List<TimetableEntity>> Timetables { get; set; }
    }
}