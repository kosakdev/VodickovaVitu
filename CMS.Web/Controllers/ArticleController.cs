using System;
using System.Threading.Tasks;
using CMS.BL.Facades;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Web.Controllers
{
    public class ArticleController : Controller
    {
        private readonly ArticleFacade _articleFacade;
        private readonly BandCompositionFacade _bandCompositionFacade;

        public ArticleController(ArticleFacade articleFacade, BandCompositionFacade bandCompositionFacade)
        {
            _articleFacade = articleFacade;
            _bandCompositionFacade = bandCompositionFacade;
        }
        
        public async Task<IActionResult> Index()
        {
            return View(await _articleFacade.GetAll());
        }
        
        public async Task<IActionResult> Details(string url)
        {
            if (url == "")
            {
                return NotFound();
            }

            var article = await _articleFacade.GetByUrl(url);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }
        
        [Route("onas")]
        public async Task<IActionResult> AboutUs()
        {
            var item = await _bandCompositionFacade.GetAll();
            return View(item);
        }
    }
}
