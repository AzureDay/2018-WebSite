using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AzureDay.WebApp.WWW.Models;
using AzureDay.WebApp.WWW.Models.Home;
using AzureDay.WebApp.Database.Services;
using AzureDay.WebApp.Database.Enums;
using AzureDay.WebApp.Database.Entities;

namespace AzureDay.WebApp.WWW.Controllers
{
    public class HomeController : Controller
    {
        private readonly Lazy<RoomService> _roomService = new Lazy<RoomService>(() => new RoomService());
        private readonly Lazy<TimetableService> _timetableService = new Lazy<TimetableService>(() => new TimetableService());
        private readonly Lazy<WorkshopService> _workshopService = new Lazy<WorkshopService>(() => new WorkshopService());
        private readonly Lazy<SpeakerService> _speakerService = new Lazy<SpeakerService>(() => new SpeakerService());
        private readonly Lazy<TopicService> _topicService = new Lazy<TopicService>(() => new TopicService());
        private readonly Lazy<PartnerService> _partnerService = new Lazy<PartnerService>(() => new PartnerService());

        public async Task<IActionResult> Index()
        {
            var model = new IndexModel
            {
                Speakers = new SpeakersModel
                {
                    SpeakersCollections = new List<List<SpeakerEntity>>()
                },
                Partners = _partnerService.Value.GetAll().ToList()
            };

            var speakers = _speakerService.Value.GetAll();
            var i = 0;
            foreach (var speaker in speakers)
            {
                List<SpeakerEntity> list;
                if (i == 0)
                {
                    list = new List<SpeakerEntity>();
                    model.Speakers.SpeakersCollections.Add(list);
                }
                else
                {
                    list = model.Speakers.SpeakersCollections.Last();
                }

                list.Add(speaker);

                if (i == 3)
                {
                    i = 0;
                }
                else
                {
                    i++;
                }
            }

            return View(model);
        }

        public async Task<IActionResult> Schedule()
        {
            var model = new ScheduleModel();

            model.Rooms = _roomService.Value
                .GetAll()
                .Where(x => x.RoomType == RoomType.LectureRoom)
                .ToList();

            model.Timetables = _timetableService.Value
                .GetTimetable()
                .GroupBy(
                    t => t.TimeStart,
                    (key, timetables) => timetables.OrderBy(t => t.Room.ColorNumber).ToList())
                .ToList();

            return View(model);
        }

        public async Task<IActionResult> Workshops()
        {
            var model = new WorkshopsModel
            {
                Workshops = new List<WorkshopModel>()
            };

            var workshops = _workshopService.Value.GetAll();
            //var workshopTickets = await AppFactory.TicketService.Value.GetWorkshopsTicketsAsync();

            foreach (var workshop in workshops)
            {
                var ticketsLeft = 0;// workshop.MaxTickets - workshopTickets.Count(x => x.WorkshopId == workshop.Id);
                if (ticketsLeft < 0)
                {
                    ticketsLeft = 0;
                }

                model.Workshops.Add(new WorkshopModel
                {
                    Workshop = workshop,
                    TicketsLeft = ticketsLeft,
                    ShowSpeakerInfo = true
                });
            }

            return View(model);
        }
        
        public async Task<IActionResult> Workshop(int id)
        {
            var model = new WorkshopModel
            {
                ShowSpeakerInfo = true
            };

            model.Workshop = _workshopService.Value.GetById(id);

            if (model.Workshop == null)
            {
                return RedirectToAction("Workshops");
            }

            model.TicketsLeft = 0; // model.Workshop.MaxTickets - (await AppFactory.TicketService.Value.GetWorkshopTicketsAsync(id)).Count;
            if (model.TicketsLeft < 0)
            {
                model.TicketsLeft = 0;
            }

            return View(model);
        }
        
        public async Task<IActionResult> Speakers()
        {
            var model = new SpeakersModel
            {
                SpeakersCollections = new List<List<SpeakerEntity>>()
            };

            var speakers = _speakerService.Value.GetAll();
            var i = 0;
            foreach (var speaker in speakers)
            {
                List<SpeakerEntity> list;
                if (i == 0)
                {
                    list = new List<SpeakerEntity>();
                    model.SpeakersCollections.Add(list);
                }
                else
                {
                    list = model.SpeakersCollections.Last();
                }

                list.Add(speaker);

                if (i == 3)
                {
                    i = 0;
                }
                else
                {
                    i++;
                }
            }

            return View(model);
        }
        
        public async Task<IActionResult> Speaker(string id)
        {
            var model = new SpeakerModel();

            model.Speaker = _speakerService.Value.GetById(id);

            if (model.Speaker == null)
            {
                return RedirectToAction("Index");
            }

            var workshops = _workshopService.Value
                .GetAll()
                .Where(x => x.Speaker.Id.Equals(model.Speaker.Id, StringComparison.InvariantCultureIgnoreCase))
                .ToList();

            model.Workshops = new List<WorkshopModel>();

            foreach (var workshop in workshops)
            {
                var ticketsLeft = 0; // workshop.MaxTickets - (await AppFactory.TicketService.Value.GetWorkshopTicketsAsync(workshop.Id)).Count;
                if (ticketsLeft < 0)
                {
                    ticketsLeft = 0;
                }

                model.Workshops.Add(new WorkshopModel
                {
                    Workshop = workshop,
                    TicketsLeft = ticketsLeft,
                    ShowSpeakerInfo = false
                });
            }

            model.Topics = _topicService.Value
                .GetAll()
                .Where(x => x.Speakers.Select(x1 => x1.Id).Any(x2 => x2.Equals(model.Speaker.Id, StringComparison.InvariantCultureIgnoreCase)))
                .OrderBy(x => x.Timetable.TimeStart)
                .ToList();

            return View(model);
        }
        
        public async Task<IActionResult> Partners()
        {
            var model = new PartnersModel();

            model.PartnersCollection = new Dictionary<PartnerType, List<PartnerEntity>>();

            foreach (var partnerType in Enum.GetValues(typeof(PartnerType)))
            {
                var partners = _partnerService.Value.GetPartnersByType((PartnerType)partnerType).ToList();
                model.PartnersCollection.Add((PartnerType)partnerType, partners);
            }

            return View(model);
        }

        public async Task<IActionResult> Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}