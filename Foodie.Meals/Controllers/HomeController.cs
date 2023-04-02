using Microsoft.AspNetCore.Mvc;

namespace Foodie.Meals.API.Controllers
{
    [ApiController]
    [Route("")]
    public class HomeController : ControllerBase
    {
        // GET
        [HttpGet]
        public IActionResult GetServiceName()
        {
            return Ok("Foodie Meals Service");
        }
    }
}
