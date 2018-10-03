using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AzureDay.WebApp.WWW.Models;
using AzureDay.WebApp.WWW.Models.Home;
using Microsoft.AspNetCore.Rewrite.Internal;

namespace AzureDay.WebApp.WWW.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var model = new IndexModel();
            
            return View(model);
        }

        public async Task<IActionResult> Schedule()
        {
            return View();
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