using System;
using System.Collections.Generic;
using System.Linq;
using AzureDay.WebApp.Database.Services;

namespace AzureDay.WebApp.Database.Entities
{
    public class TopicEntity: BaseEntity<int>
    {
        private readonly Lazy<TimetableService> _timetableService = new Lazy<TimetableService>(() => new TimetableService());

        public string Title { get; set; }
        public string Description { get; set; }
        public LanguageEntity Language { get; set; }

        public List<SpeakerEntity> Speakers { get; set; }

        private TimetableEntity _timetable;

        public TimetableEntity Timetable
        {
            get
            {
                if (_timetable == null)
                {
                    _timetable = _timetableService.Value.GetAll()
                        .Where(x => x.Topic != null)
                        .SingleOrDefault(x => x.Topic.Id == Id);
                }
                return _timetable;
            }
        }

        public TopicEntity()
        {
            Language = new LanguageEntity();
            Speakers = new List<SpeakerEntity>();
        }
    }
}