#nullable enable
using System.Threading.Tasks;
using CMS.BL.Facades;
using CMS.Web.Models;
using CMS.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CMS.Web.Controllers
{
    [Route("kontakt")]
    public class ContactController : Controller
    {
        private readonly BandCompositionFacade _bandCompositionFacade;
        private readonly EventTypeFacade _eventTypeFacade;
        private readonly IEmailSender _emailSender;
        private readonly IConfiguration _configuration;
        private readonly ArticleFacade _articleFacade;

        public ContactController(BandCompositionFacade bandCompositionFacade, EventTypeFacade eventTypeFacade, 
            IEmailSender emailSender, IConfiguration configuration, ArticleFacade articleFacade)
        {
            _bandCompositionFacade = bandCompositionFacade;
            _eventTypeFacade = eventTypeFacade;
            _emailSender = emailSender;
            _configuration = configuration;
            _articleFacade = articleFacade;
        }
        
        public async Task<IActionResult> Index()
        {
            ViewBag.bandComposition = new SelectList(await _bandCompositionFacade.GetAll(), "Id", "Title", null);
            ViewBag.eventType = new SelectList(await _eventTypeFacade.GetAll(), "Id", "Name", null);

            ViewBag.contactInfo = await _articleFacade.GetByUrl("contact-info");

            ViewBag.Error = false;

            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(ContactModel item)
        {
            ViewBag.bandComposition = new SelectList(await _bandCompositionFacade.GetAll(), "Id", "Title", null);
            ViewBag.eventType = new SelectList(await _eventTypeFacade.GetAll(), "Id", "Name", null);

            ViewBag.contactInfo = await _articleFacade.GetByUrl("contact-info");

            ViewBag.Error = true;
            
            if (ModelState.IsValid)
            {
                try
                {
                    /*
                     * SEND EMAIL
                     */
                    string message = $"<p><strong>Jméno:</strong> {item.Name}</p>" +
                                     $"<p><strong>Místo:</strong> {item.Place}</p>" +
                                     $"<p><strong>Datum:</strong> {item.DateTime.ToString("dd. MM. yyyy")}</p>" +
                                     $"<p><strong>Telefon:</strong> {item.MobileNumber}</p>" +
                                     $"<p><strong>Email:</strong> {item.Email}</p>" +
                                     $"<p><strong>Sestava:</strong> {(await _bandCompositionFacade.GetById(item.BandCompositionId)).Title}</p>" +
                                     $"<p><strong>Typ akce:</strong> {(await _eventTypeFacade.GetById(item.EventTypeId)).Name}</p>" +
                                     $"<p><strong>Popis:</strong> {item.Notes}</p>";
                    await _emailSender.SendEmailAsync(_configuration["ContactFormEmail"], "Vzkaz z webu", message);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return View(item);
                }
                return RedirectToAction(nameof(Mail), "Contact", new {area=""});
            }
            
            return View(item);
        }
        
        [HttpGet("email-odeslan")]
        public async Task<IActionResult> Mail()
        {
            var item = new SendMailModel()
            {
                Article = await _articleFacade.GetByUrl("send-email")
            };
            return View(item);
        }
    }
}