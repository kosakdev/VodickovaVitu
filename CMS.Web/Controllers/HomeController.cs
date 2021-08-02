using System;
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
        private readonly ArticleFacade _articleFacade;
        private readonly VideoFacade _videoFacade;

        public HomeController(ILogger<HomeController> logger, CalendarFacade calendarFacade, ArticleFacade articleFacade, VideoFacade videoFacade)
        {
            _logger = logger;
            _calendarFacade = calendarFacade;
            _articleFacade = articleFacade;
            _videoFacade = videoFacade;
        }

        public async Task<IActionResult> Index()
        {
            var item = new HomePageModel
            {
                CalendarList = await _calendarFacade.GetCountActual(3),
                Article = await _articleFacade.GetByUrl("main-page"),
                Video = await _videoFacade.GetById(Guid.Parse("3274022f-a350-4d02-b753-2aafaedeffc1"))
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