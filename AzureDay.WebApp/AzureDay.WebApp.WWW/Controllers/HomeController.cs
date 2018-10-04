using System;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AzureDay.WebApp.WWW.Models;
using AzureDay.WebApp.WWW.Models.Home;
using AzureDay.WebApp.Database.Services;
using AzureDay.WebApp.Database.Enums;

namespace AzureDay.WebApp.WWW.Controllers
{
    public class HomeController : Controller
    {
        private readonly Lazy<RoomService> _roomService = new Lazy<RoomService>(() => new RoomService());
        private readonly Lazy<TimetableService> _timetableService = new Lazy<TimetableService>(() => new TimetableService());

        public async Task<IActionResult> Index()
        {
            var model = new IndexModel();
            
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
                .GetAll()
                .GroupBy(
                    t => t.TimeStart,
                    (key, timetables) => timetables.OrderBy(t => t.Room.ColorNumber).ToList())
                .ToList();

            return View(model);
        }
        
        public async Task<IActionResult> Workshops()
        {
            return View();
        }
        
        public async Task<IActionResult> Workshop(string id)
        {
            return View();
        }
        
        public async Task<IActionResult> Speakers()
        {
            return View();
        }
        
        public async Task<IActionResult> Speaker(string id)
        {
            return View();
        }
        
        public async Task<IActionResult> Partners()
        {
            return View();
        }

        public async Task<IActionResult> Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}