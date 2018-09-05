using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AzureDay.WebApp.WWW.Models;

namespace AzureDay.WebApp.WWW.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Schedule()
        {
            return View();
        }
        
        public IActionResult Workshops()
        {
            return View();
        }
        
        public IActionResult Workshop(string id)
        {
            return View();
        }
        
        public IActionResult Speakers()
        {
            return View();
        }
        
        public IActionResult Speaker(string id)
        {
            return View();
        }
        
        public IActionResult Partners()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}