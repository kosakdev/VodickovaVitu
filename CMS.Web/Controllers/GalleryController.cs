using Microsoft.AspNetCore.Mvc;

namespace CMS.Web.Controllers
{
    public class GalleryController : Controller
    {
        [Route("galerie")]
        public IActionResult Index()
        {
            return View();
        }
    }
}