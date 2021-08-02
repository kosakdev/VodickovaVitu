using System;
using System.Threading.Tasks;
using AutoMapper;
using CMS.BL.Facades;
using CMS.Models.Video;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CMS.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "Admin")]
    public class VideoController : Controller
    {
        private readonly VideoFacade _videoFacade;
        private readonly IMapper _mapper;

        public VideoController(VideoFacade videoFacade, IMapper mapper)
        {
            _videoFacade = videoFacade;
            _mapper = mapper;
        }
        
        public async Task<IActionResult> Index()
        {
            var items = await _videoFacade.GetAll();
            return View(items);
        }

        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VideoNewModel item)
        {
            if (ModelState.IsValid)
            {
                Guid id = await _videoFacade.Create(item);
                return RedirectToAction(nameof(Index), "Article", new {area="Admin"});
            }
            return View(item);
        }
        
         public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _videoFacade.GetById(id.Value);
            
            return View(_mapper.Map<VideoUpdateModel>(item));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, VideoUpdateModel item)
        {
            if (id != item.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _videoFacade.Update(item);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return View(item);
                }
                return RedirectToAction(nameof(Index), "Article", new {area="Admin"});
            }
            
            return RedirectToAction(nameof(Index));
        }
        
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _videoFacade.GetById(id.Value);
            return View(item);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _videoFacade.Remove(id);
            return RedirectToAction(nameof(Index), "Article", new {area="Admin"});
        }
    }
}