using Foodie.Common.Api.Authorization;
using Foodie.Common.Api.Controllers;
using Foodie.Common.Api.Results;
using Foodie.Common.Enums;
using Foodie.Meals.Application.Functions.Locations.Commands.CreateLocation;
using Foodie.Meals.Application.Functions.Locations.Commands.DeleteLocation;
using Foodie.Meals.Application.Functions.Locations.Commands.UpdateLocation;
using Foodie.Meals.Application.Functions.Locations.Queries.GetLocationById;
using Foodie.Meals.Application.Functions.Locations.Queries.GetLocations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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
        [RequiredRoles(ApplicationUserRole.Admin)]
        public async Task<IActionResult> CreateLocation([FromBody] CreateLocationCommand createLocationCommand)
        {
            var result = await mediator.Send(createLocationCommand);

            return result.Match(
                onSuccess: () => Ok(result.Value),
                onFailure: HandleFailure);
        }

        // PUT api/locations/5
        [HttpPut("{id}")]
        [RequiredRoles(ApplicationUserRole.Admin)]
        public async Task<IActionResult> UpdateLocation(int id, [FromBody] UpdateLocationCommand updateLocationCommand)
        {
            if (id != updateLocationCommand.Id)
            {
                return BadRequest();
            }

            var result = await mediator.Send(updateLocationCommand);

            return result.Match(
                onSuccess: () => Ok(result.Value),
                onFailure: HandleFailure);
        }

        // DELETE api/locations/5
        [HttpDelete("{id}")]
        [RequiredRoles(ApplicationUserRole.Admin)]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            var command = new DeleteLocationCommand(id);
            var result = await mediator.Send(command);

            return result.Match(
                onSuccess: () => Ok(result.Value),
                onFailure: HandleFailure);
        }

        // GET api/locations/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocation(int id)
        {
            var query = new GetLocationByIdQuery(id);
            var result = await mediator.Send(query);

            return result.Match(
                onSuccess: () => Ok(result.Value),
                onFailure: HandleFailure);
        }

        // GET api/locations
        [HttpGet]
        public async Task<IActionResult> GetLocations([FromQuery] GetLocationsQuery getLocationsQuery)
        {
            var result = await mediator.Send(getLocationsQuery);

            return result.Match(
                onSuccess: () => Ok(result.Value),
                onFailure: HandleFailure);
        }
    }
}
