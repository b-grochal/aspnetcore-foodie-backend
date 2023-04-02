using Microsoft.AspNetCore.Mvc;

namespace Foodie.Orders.API.Controllers
{
    [ApiController]
    [Route("")]
    public class HomeController : ControllerBase
    {
        // GET
        [HttpGet]
        public IActionResult GetServiceName()
        {
            return Ok("Foodie Orders Service");
        }
    }
}
