using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using CMS.BL.Facades;
using CMS.DAL;
using CMS.DAL.Entities;
using CMS.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CMS.Web.Controllers
{
    public class CalendarController : Controller
    {
        private readonly CalendarFacade _calendarFacade;

        public CalendarController(CalendarFacade calendarFacade)
        {
            _calendarFacade = calendarFacade;
        }
        
        [Route("kalendar")]
        public async Task<IActionResult> Index()
        {
            var item = new CalendarListsModel
            {
                ActualData = await _calendarFacade.GetAllNew(),
                OldData = await _calendarFacade.GetAllOld()
            };
            return View(item);
        }
        
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventItem = await _calendarFacade.GetById(id.Value);
            if (eventItem == null)
            {
                return NotFound();
            }

            return View(eventItem);
        }

        public async Task<string> GetNext(int skip)
        {
            var items = await _calendarFacade.GetAllNew(skip);

            return JsonSerializer.Serialize(items); 
        }
        
        public async Task<string> GetPrevious(int skip)
        {
            var items = await _calendarFacade.GetAllOld(skip);

            return JsonSerializer.Serialize(items); 
        }
    }
}
