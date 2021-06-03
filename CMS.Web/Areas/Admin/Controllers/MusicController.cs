using System;
using System.Threading.Tasks;
using AutoMapper;
using CMS.BL.Facades;
using CMS.Models.Calendar;
using CMS.Models.Music;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CMS.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "Admin")]
    public class MusicController : Controller
    {
        private readonly MusicFacade _musicFacade;
        private readonly IMapper _mapper;

        public MusicController(MusicFacade musicFacade, IMapper mapper)
        {
            _musicFacade = musicFacade;
            _mapper = mapper;
        }
        
        public async Task<IActionResult> Index()
        {
            var items = await _musicFacade.GetAll();
            return View(items);
        }

        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MusicNewModel item)
        {
            if (ModelState.IsValid)
            {
                Guid id = await _musicFacade.Create(item);
                return RedirectToAction(nameof(Index), "Music", new {area="Admin"});
            }
            return View(item);
        }
        
         public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _musicFacade.GetById(id.Value);
            
            return View(_mapper.Map<MusicUpdateModel>(item));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, MusicUpdateModel item)
        {
            if (id != item.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _musicFacade.Update(item);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return View(item);
                }
                return RedirectToAction(nameof(Index), "Music", new {area="Admin"});
            }
            
            return RedirectToAction(nameof(Index));
        }
        
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _musicFacade.GetById(id.Value);
            return View(item);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _musicFacade.Remove(id);
            return RedirectToAction(nameof(Index), "Music", new {area="Admin"});
        }
    }
}