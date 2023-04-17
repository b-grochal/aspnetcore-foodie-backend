using Microsoft.AspNetCore.Mvc;

namespace Foodie.Basket.API.Controllers
{
    [ApiController]
    [Route("")]
    public class HomeController : ControllerBase
    {
        // GET
        [HttpGet]
        public IActionResult GetServiceName()
        {
            return Ok("Foodie Basket Service");
        }
    }
}
