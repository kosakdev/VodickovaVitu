using System;
using System.Linq;
using System.Threading.Tasks;
using CMS.BL.Facades;
using CMS.DAL;
using CMS.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CMS.Web.Controllers
{
    public class EventController : Controller
    {
        private readonly EventFacade _eventFacade;

        public EventController(EventFacade eventFacade)
        {
            _eventFacade = eventFacade;
        }
        
        public async Task<IActionResult> Index()
        {
            return View(await _eventFacade.GetAll());
        }
        
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventItem = await _eventFacade.GetById(id.Value);
            if (eventItem == null)
            {
                return NotFound();
            }

            return View(eventItem);
        }
    }
}
