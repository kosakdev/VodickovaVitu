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
    public class ContactController : Controller
    {
        private readonly BandCompositionFacade _bandCompositionFacade;
        private readonly EventTypeFacade _eventTypeFacade;
        private readonly IEmailSender _emailSender;
        private readonly IConfiguration _configuration;

        public ContactController(BandCompositionFacade bandCompositionFacade, EventTypeFacade eventTypeFacade, IEmailSender emailSender, IConfiguration configuration)
        {
            _bandCompositionFacade = bandCompositionFacade;
            _eventTypeFacade = eventTypeFacade;
            _emailSender = emailSender;
            _configuration = configuration;
        }
        [HttpGet("kontakt")]
        public async Task<IActionResult> Index()
        {
            ViewBag.bandComposition = new SelectList(await _bandCompositionFacade.GetAll(), "Id", "Title", null);
            ViewBag.eventType = new SelectList(await _eventTypeFacade.GetAll(), "Id", "Name", null);

            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendMail(ContactModel item)
        {
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
                                     $"<p><strong>Typ akce:</strong> {(await _eventTypeFacade.GetById(item.EventTypeId)).Name}</p>";
                    await _emailSender.SendEmailAsync(_configuration["ContactFormEmail"], "Vzkaz z webu", message);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return RedirectToAction(nameof(Mail), "Contact", new {area=""});
                }
                return RedirectToAction(nameof(Mail), "Contact", new {area=""});
            }
            
            return RedirectToAction(nameof(Mail), "Contact", new {area=""});
        }
        
        [HttpGet("email-odeslan")]
        public async Task<IActionResult> Mail()
        {
            return View();
        }
    }
}