using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CMS.Web.Controllers
{
    public class MusicController : Controller
    {
        [Route("co-hrajeme")]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<string> VideoList()
        {
            return
                @"[{""videoId"": ""oT8UaGHWcMg"",""title"": ""Saturday Sun - Vance Joy (Markéta Vodičková & Filip Vítů cover)""},{""videoId"": ""BSoL3M6pdt0"",""title"": ""Go Tell It on the Mountain - Markéta Vodičková & Filip Vítů cover""},{""videoId"": ""dywm0wsupUs"",""title"": ""Markéta Vodičková & Filip Vítů - Půlnoční sen""},{""videoId"": ""gnuBWddbYz0"",""title"": ""Just The Two Us - Bill Withers (Markéta Vodičková & Filip Vítů feat. Štěpán Holík & Libor Jandík""},{""videoId"": ""dNdqpGmG9l4"",""title"": ""September - Earth, Wind & Fire cover (Markéta Vodičková & Filip Vítů)""},{""videoId"": ""UB4E9-ePOSY"",""title"": ""Don't look back in anger - Oasis (Markéta Vodičková & Filip Vítů cover)""},{""videoId"": ""EcloRQsgef0"",""title"": ""I say a little prayer for you (live) - Markéta Vodičková & Filip Vítů""},{""videoId"": ""tW_N2K_xnzw"",""title"": ""Pumped up kicks - Foster the People (Markéta Vodičková & Filip Vítů feat. Libor Jandík cover)""},{""videoId"": ""HDqHX9sh0Gc"",""title"": ""Your song - Elton John (Markéta Vodičková & Filip Vítů cover)""}]";
        }
    }
}