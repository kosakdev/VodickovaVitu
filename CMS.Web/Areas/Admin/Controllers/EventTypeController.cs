using System;
using System.Threading.Tasks;
using AutoMapper;
using CMS.BL.Facades;
using CMS.Models.EventType;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CMS.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "Admin")]
    public class EventTypeController : Controller
    {
        private readonly EventTypeFacade _eventTypeFacade;
        private readonly IMapper _mapper;

        public EventTypeController(EventTypeFacade eventTypeFacade, IMapper mapper)
        {
            _eventTypeFacade = eventTypeFacade;
            _mapper = mapper;
        }
        
        public async Task<IActionResult> Index()
        {
            var items = await _eventTypeFacade.GetAll();
            return View(items);
        }

        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EventTypeNewModel item)
        {
            if (ModelState.IsValid)
            {
                Guid id = await _eventTypeFacade.Create(item);
                return RedirectToAction(nameof(Index), "EventType", new {area="Admin"});
            }
            return View(item);
        }
        
         public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _eventTypeFacade.GetById(id.Value);
            
            return View(_mapper.Map<EventTypeUpdateModel>(item));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, EventTypeUpdateModel item)
        {
            if (id != item.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _eventTypeFacade.Update(item);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return View(item);
                }
                return RedirectToAction(nameof(Index), "EventType", new {area="Admin"});
            }
            
            return RedirectToAction(nameof(Index));
        }
        
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _eventTypeFacade.GetById(id.Value);
            return View(item);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _eventTypeFacade.Remove(id);
            return RedirectToAction(nameof(Index), "EventType", new {area="Admin"});
        }
    }
}