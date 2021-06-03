using System;
using System.Threading.Tasks;
using AutoMapper;
using CMS.BL.Facades;
using CMS.Models.Calendar;
using CMS.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CMS.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "Admin")]
    public class CalendarController : Controller
    {
        private readonly CalendarFacade _calendarFacade;
        private readonly BandCompositionFacade _bandCompositionFacade;
        private readonly EventTypeFacade _eventTypeFacade;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMapper _mapper;
        
        public CalendarController(CalendarFacade calendarFacade, BandCompositionFacade bandCompositionFacade, 
            EventTypeFacade eventTypeFacade, IWebHostEnvironment webHostEnvironment, IMapper mapper)
        {
            _calendarFacade = calendarFacade;
            _bandCompositionFacade = bandCompositionFacade;
            _eventTypeFacade = eventTypeFacade;
            _webHostEnvironment = webHostEnvironment;
            _mapper = mapper;
        }
        
        public async Task<IActionResult> Index()
        {
            return View(await _calendarFacade.GetAll());
        }
        
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _calendarFacade.GetById(id.Value);

            return View(item);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.bandComposition = new SelectList(await _bandCompositionFacade.GetAll(), "Id", "Title", null);
            ViewBag.eventType = new SelectList(await _eventTypeFacade.GetAll(), "Id", "Name", null);
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CalendarNewModel item)
        {
            if (ModelState.IsValid)
            {
                Guid id = await _calendarFacade.Create(item);
                return RedirectToAction(nameof(Index), "Calendar", new {area="Admin"});
            }
            return View(item);
        }
        
         public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _calendarFacade.GetById(id.Value);
            
            ViewBag.bandComposition = new SelectList(await _bandCompositionFacade.GetAll(), "Id", "Title", item.BandCompositionId);
            ViewBag.eventType = new SelectList(await _eventTypeFacade.GetAll(), "Id", "Name", item.EventTypeId);
            
            return View(_mapper.Map<CalendarUpdateModel>(item));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, CalendarUpdateModel item)
        {
            if (id != item.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _calendarFacade.Update(item);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return View(item);
                }
                return RedirectToAction(nameof(Index), "Calendar", new {area="Admin"});
            }
            
            return RedirectToAction(nameof(Index));
        }
        
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _calendarFacade.GetById(id.Value);
            return View(item);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _calendarFacade.Remove(id);
            return RedirectToAction(nameof(Index), "Calendar", new {area="Admin"});
        }
    }
}