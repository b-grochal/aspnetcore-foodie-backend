using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Foodie.Identity.API.Controllers
{
    [ApiController]
    [Route("")]
    public class HomeController : ControllerBase
    {
        // GET
        [HttpGet]
        public string GetServiceName()
        {
            return "Foodie Identity Service";
        }
    }
}
