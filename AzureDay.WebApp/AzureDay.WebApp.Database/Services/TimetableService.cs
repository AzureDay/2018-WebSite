using System.Collections.Generic;
using AzureDay.WebApp.Database.Entities;

namespace AzureDay.WebApp.Database.Services
{
    public class TimetableService : BaseService<TimetableEntity, int>
    {
        private readonly List<TimetableEntity> _timetables = new List<TimetableEntity>();

        private readonly RoomService _roomService = new RoomService();
        private readonly TopicService _topicService = new TopicService();

        protected override List<TimetableEntity> PopulateStorage()
        {
            _timetables.AddRange(new List<TimetableEntity>
            {
                new TimetableEntity {Id = 1, TimeStart = "8:15", TimeEnd = "9:00", Room = _roomService.CoffeeBreak, Topic = _topicService.CoffeeBreak },
                new TimetableEntity { TimeStart = "10:15", TimeEnd = "10:30", Room = _roomService.CoffeeBreak},
                new TimetableEntity { TimeStart = "11:30", TimeEnd = "12:00", Room = _roomService.CoffeeBreak, Topic = _topicService.CoffeeBreak },
                new TimetableEntity { TimeStart = "13:00", TimeEnd = "13:15", Room = _roomService.CoffeeBreak },
                new TimetableEntity { TimeStart = "14:15", TimeEnd = "14:45", Room = _roomService.CoffeeBreak, Topic = _topicService.Lunch },
                new TimetableEntity { TimeStart = "15:45", TimeEnd = "16:00", Room = _roomService.CoffeeBreak },
                new TimetableEntity { TimeStart = "17:00", TimeEnd = "17:30", Room = _roomService.CoffeeBreak, Topic = _topicService.CoffeeBreak },
                new TimetableEntity { TimeStart = "19:15", TimeEnd = "21:00", Room = _roomService.CoffeeBreak, Topic = _topicService.Afterparty }
            });

            return _timetables;
        }
    }
}