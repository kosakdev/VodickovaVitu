using Microsoft.AspNetCore.Mvc;

namespace CMS.Web.Areas.Admin.Controllers
{
    public class MusicController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}