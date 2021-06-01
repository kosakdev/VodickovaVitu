using Microsoft.AspNetCore.Mvc;

namespace CMS.Web.Controllers
{
    public class ContactController : Controller
    {
        [Route("kontakt")]
        public IActionResult Index()
        {
            return View();
        }
    }
}