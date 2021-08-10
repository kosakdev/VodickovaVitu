using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CMS.BL.Facades;
using CMS.Models.Calendar;
using CMS.Models.Music;
using CMS.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
        private readonly IWebHostEnvironment _webHostEnvironment;

        public MusicController(MusicFacade musicFacade, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _musicFacade = musicFacade;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }
        
        public async Task<IActionResult> Index()
        {
            var items = await _musicFacade.GetAll();
            return View(items);
        }
        
        private async Task<bool> UploadFile(IFormFile file)
        {
            if (file.Length <= 0) return false;
            
            var filename = "Repertoar-Marketa-Vodickova-Filip-Vitu" + "." + file.FileName.Split('.').Last();
            var folderPath = Path.Combine(_webHostEnvironment.WebRootPath, "whatweplay");
            if (!Directory.Exists(folderPath)) {
                Directory.CreateDirectory(folderPath);
            }
            var filePath = Path.Combine(folderPath, filename);

            await using var stream = System.IO.File.Create(filePath);
            await file.CopyToAsync(stream);

            return true;
        }
        
        public IActionResult UpdateFile()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateFile(FileModel item)
        {
            if (ModelState.IsValid)
            {
                await UploadFile(item.FormFile);
                
                return RedirectToAction(nameof(Index), "Music", new {area="Admin"});
            }
            return View(item);
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