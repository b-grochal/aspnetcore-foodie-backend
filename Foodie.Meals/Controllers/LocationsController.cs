using Foodie.Meals.Application.Functions.Locations.Commands.CreateLocation;
using Foodie.Meals.Application.Functions.Locations.Commands.DeleteLocation;
using Foodie.Meals.Application.Functions.Locations.Commands.UpdateLocation;
using Foodie.Meals.Application.Functions.Locations.Queries.GetLocationById;
using Foodie.Meals.Application.Functions.Locations.Queries.GetLocations;
using Foodie.Shared.Authorization;
using Foodie.Shared.Controllers;
using Foodie.Shared.Extensions.Attributes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Foodie.Meals.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : BaseController
    {
        public LocationsController(IMediator mediator) : base(mediator) { }

        // POST api/locations
        [HttpPost]
        [Roles(RolesDictionary.Admin)]
        public async Task<IActionResult> CreateLocation([FromBody] CreateLocationCommand createLocationCommand)
        {
            createLocationCommand.CreatedBy = GetApplicationUserClaim(ClaimTypes.Email);
            var result = await mediator.Send(createLocationCommand);
            return Ok(result);
        }

        // PUT api/locations/5
        [HttpPut("{id}")]
        [Roles(RolesDictionary.Admin)]
        public async Task<IActionResult> UpdateLocation(int id, [FromBody] UpdateLocationCommand updateLocationCommand)
        {
            if (id != updateLocationCommand.Id)
            {
                return BadRequest();
            }

            updateLocationCommand.LastModifiedBy = GetApplicationUserClaim(ClaimTypes.Email);
            var result = await mediator.Send(updateLocationCommand);
            return Ok(result);
        }

        // DELETE api/locations/5
        [HttpDelete("{id}")]
        [Roles(RolesDictionary.Admin)]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            var command = new DeleteLocationCommand(id);
            var result = await mediator.Send(command);
            return Ok(result);
        }

        // GET api/locations/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocation(int id)
        {
            var query = new GetLocationByIdQuery(id);
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
    }
}
