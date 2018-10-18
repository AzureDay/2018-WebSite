using System.Collections.Generic;
using System.Linq;
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

            _timetables.AddRange(new List<TimetableEntity> // webdev
			{
                new TimetableEntity { TimeStart = "10:30", TimeEnd = "11:30", Room = _roomService.Room1, Topic = _topicService.ABoyko_01 },
                new TimetableEntity { TimeStart = "12:00", TimeEnd = "13:00", Room = _roomService.Room1, Topic = _topicService.ASurkov_01 },
                new TimetableEntity { TimeStart = "13:15", TimeEnd = "14:15", Room = _roomService.Room1, Topic = _topicService.SSultanov_01 },
                //new TimetableEntity { TimeStart = "14:45", TimeEnd = "15:45", Room = _roomService.Room1, Topic = _topicService. },
                //new TimetableEntity { TimeStart = "16:00", TimeEnd = "17:00", Room = _roomService.Room1, Topic = _topicService. },
                //new TimetableEntity { TimeStart = "17:30", TimeEnd = "18:30", Room = _roomService.Room1, Topic = _topicService. }
            });

            _timetables.AddRange(new List<TimetableEntity> // iot
			{
                new TimetableEntity { TimeStart = "10:30", TimeEnd = "11:30", Room = _roomService.Room2, Topic = _topicService.SBielskyi_01 },
                new TimetableEntity { TimeStart = "12:00", TimeEnd = "13:00", Room = _roomService.Room2, Topic = _topicService.ILeontiev_01 },
                new TimetableEntity { TimeStart = "13:15", TimeEnd = "14:15", Room = _roomService.Room2, Topic = _topicService.EAuberix_01 },
                //new TimetableEntity { TimeStart = "14:45", TimeEnd = "15:45", Room = _roomService.Room2, Topic = _topicService. },
                //new TimetableEntity { TimeStart = "16:00", TimeEnd = "17:00", Room = _roomService.Room2, Topic = _topicService. },
                //new TimetableEntity { TimeStart = "17:30", TimeEnd = "18:30", Room = _roomService.Room2, Topic = _topicService. }
            });

            _timetables.AddRange(new List<TimetableEntity> // AInML
			{
                new TimetableEntity { TimeStart = "10:30", TimeEnd = "11:30", Room = _roomService.Room3, Topic = _topicService.SLebedenko_01 },
                new TimetableEntity { TimeStart = "12:00", TimeEnd = "13:00", Room = _roomService.Room3, Topic = _topicService.EPolonychko_01 },
                new TimetableEntity { TimeStart = "13:15", TimeEnd = "14:15", Room = _roomService.Room3, Topic = _topicService.VTsykunov_01 },
                //new TimetableEntity { TimeStart = "14:45", TimeEnd = "15:45", Room = _roomService.Room3, Topic = _topicService. },
                //new TimetableEntity { TimeStart = "16:00", TimeEnd = "17:00", Room = _roomService.Room3, Topic = _topicService. },
                //new TimetableEntity { TimeStart = "17:30", TimeEnd = "18:30", Room = _roomService.Room3, Topic = _topicService. }
            });

            return _timetables;
        }

        public List<TimetableEntity> GetTimetable()
        {
            return Storage
                .OrderBy(t => t.TimeStartHours)
                .ThenBy(t => t.TimeStartMinutes)
                .ThenBy(t => t.Room.RoomType.ToString())
                .ThenBy(t => t.Room.Title)
                .ToList();
        }
    }
}