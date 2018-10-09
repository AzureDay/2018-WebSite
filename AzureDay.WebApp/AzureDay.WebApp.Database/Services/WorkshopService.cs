using System;
using System.Collections.Generic;
using AzureDay.WebApp.Database.Entities;

namespace AzureDay.WebApp.Database.Services
{
    public sealed class WorkshopService : BaseService<WorkshopEntity, int>
    {
        private readonly LanguageService _languageService = new LanguageService();
        private readonly SpeakerService _speakerService = new SpeakerService();
        private readonly RoomService _roomService = new RoomService();

        private readonly List<WorkshopEntity> _workshops = new List<WorkshopEntity>();

        protected override List<WorkshopEntity> PopulateStorage()
        {
            _workshops.AddRange(new List<WorkshopEntity>
            {
                new WorkshopEntity
                {
                    Id = 2,
                    Language = _languageService.Russian,
                    Room = _roomService.Workshop2,
                    Speaker = _speakerService.DIvanov(),
                    MaxTickets = 0, // ok
					Title = Localization.App.Service.Workshops.DIvanov_01.Title,
                    Description = Localization.App.Service.Workshops.DIvanov_01.Description.Replace(Environment.NewLine, "<br/>")
                }
            });

            return _workshops;
        }
    }
}