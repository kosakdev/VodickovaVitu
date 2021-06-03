using System.Diagnostics;
using System.Threading.Tasks;
using CMS.BL.Facades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CMS.Web.Models;

namespace CMS.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CalendarFacade _calendarFacade;

        public HomeController(ILogger<HomeController> logger, CalendarFacade calendarFacade)
        {
            _logger = logger;
            _calendarFacade = calendarFacade;
        }

        public async Task<IActionResult> Index()
        {
            var item = new HomePageModel
            {
                CalendarList = await _calendarFacade.GetCountActual(3)
            };
            return View(item);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}