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
        public IActionResult GetServiceName()
        {
            return Ok("Foodie Identity Service");
        }
    }
}
