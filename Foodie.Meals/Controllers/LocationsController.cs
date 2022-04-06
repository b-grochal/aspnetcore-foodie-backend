using Foodie.Meals.Application.Functions.Locations.Commands.CreateLocation;
using Foodie.Meals.Application.Functions.Locations.Commands.DeleteLocation;
using Foodie.Meals.Application.Functions.Locations.Commands.UpdateLocation;
using Foodie.Meals.Application.Functions.Locations.Queries.GetLocationById;
using Foodie.Meals.Application.Functions.Locations.Queries.GetLocations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Foodie.Meals.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : Controller
    {
        private readonly IMediator mediator;

        public LocationsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // POST api/locations
        [HttpPost]
        public async Task<IActionResult> CreateLocation([FromBody] CreateLocationCommand createLocationCommand)
        {
            createLocationCommand.CreatedBy = GetUserEmail();
            await mediator.Send(createLocationCommand);
            return Ok();
        }

        // PUT api/locations/5
        [HttpPut("{locationId}")]
        public async Task<IActionResult> UpdateLocation(int locationId, [FromBody] UpdateLocationCommand updateLocationCommand)
        {
            if (locationId != updateLocationCommand.LocationId)
            {
                return BadRequest();
            }

            updateLocationCommand.LastModifiedBy = GetUserEmail();
            await mediator.Send(updateLocationCommand);
            return Ok();
        }

        // DELETE api/locations/5
        [HttpDelete("{locationId}")]
        public async Task<IActionResult> DeleteLocation(int locationId)
        {
            var command = new DeleteLocationCommand(locationId);
            await mediator.Send(command);
            return Ok();
        }

        // GET api/locations/5
        [HttpGet("{locationId}")]
        public async Task<IActionResult> GetLocation(int locationId)
        {
            var query = new GetLocationByIdQuery(locationId);
            var result = await mediator.Send(query);
            return Ok(result);
        }

        // GET api/locations
        [HttpGet]
        public async Task<IActionResult> GetLocations([FromQuery] GetLocationsQuery getLocationsQuery)
        {
            var result = await mediator.Send(getLocationsQuery);
            return Ok(result);
        }

        private string GetUserEmail()
        {
            return User.FindFirstValue(ClaimTypes.Email);
        }
    }
}
