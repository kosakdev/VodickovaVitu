using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CMS.BL.Facades;
using CMS.Models.BandComposition;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CMS.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "Admin")]
    public class BandCompositionController : Controller
    {
        private readonly BandCompositionFacade _bandCompositionFacade;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMapper _mapper;
        
        public BandCompositionController(BandCompositionFacade bandCompositionFacade, IWebHostEnvironment webHostEnvironment, IMapper mapper)
        {
            _bandCompositionFacade = bandCompositionFacade;
            _webHostEnvironment = webHostEnvironment;
            _mapper = mapper;
        }
        
        public async Task<IActionResult> Index()
        {
            var items = await _bandCompositionFacade.GetAll();
            return View(items);
        }
        
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _bandCompositionFacade.GetById(id.Value);

            return View(item);
        }

        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BandCompositionNewModel item)
        {
            if (ModelState.IsValid)
            {
                if (item.FormFile != null && item.FormFile.Length > 0)
                {
                    item.FileName = await UploadFile(item.FormFile);
                }
                
                Guid id = await _bandCompositionFacade.Create(item);
                return RedirectToAction(nameof(Index), "BandComposition", new {area="Admin"});
            }
            return View(item);
        }

        private async Task<string> UploadFile(IFormFile file)
        {
            if (file.Length <= 0) return "";
            
            var filename = Path.GetRandomFileName() + "." + file.FileName.Split('.').Last();
            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", filename);

            await using var stream = System.IO.File.Create(filePath);
            await file.CopyToAsync(stream);

            return filename;
        }
        
         public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _bandCompositionFacade.GetById(id.Value);
            
            return View(_mapper.Map<BandCompositionUpdateModel>(item));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, BandCompositionUpdateModel item)
        {
            if (id != item.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (item.FormFile != null && item.FormFile.Length > 0)
                    {
                        item.FileName = await UploadFile(item.FormFile);
                    }
                    
                    await _bandCompositionFacade.Update(item);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return View(item);
                }
                return RedirectToAction(nameof(Index), "BandComposition", new {area="Admin"});
            }
            
            return RedirectToAction(nameof(Index));
        }
        
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _bandCompositionFacade.GetById(id.Value);
            return View(item);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _bandCompositionFacade.Remove(id);
            return RedirectToAction(nameof(Index), "BandComposition", new {area="Admin"});
        }
    }
}