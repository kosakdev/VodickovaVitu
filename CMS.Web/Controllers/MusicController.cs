using System.Text.Json;
using System.Threading.Tasks;
using CMS.BL.Facades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CMS.Web.Controllers
{
    public class MusicController : Controller
    {
        private readonly MusicFacade _musicFacade;

        public MusicController(MusicFacade musicFacade)
        {
            _musicFacade = musicFacade;
        }
        [Route("co-hrajeme")]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<string> VideoList()
        {
            return JsonSerializer.Serialize(await _musicFacade.GetAll()); 
        }
    }
}