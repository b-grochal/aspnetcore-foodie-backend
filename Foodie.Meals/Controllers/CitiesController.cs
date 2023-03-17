using Foodie.Meals.Application.Functions.Cities.Commands.CreateCity;
using Foodie.Meals.Application.Functions.Cities.Commands.DeleteCity;
using Foodie.Meals.Application.Functions.Cities.Commands.UpdateCity;
using Foodie.Meals.Application.Functions.Cities.Queries.GetCities;
using Foodie.Meals.Application.Functions.Cities.Queries.GetCityById;
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
    public class CitiesController : BaseController
    {
        public CitiesController(IMediator mediator) : base(mediator) { }

        // POST api/cities
        [HttpPost]
        [Roles(RolesDictionary.Admin)]
        public async Task<IActionResult> CreateCity([FromBody] CreateCityCommand createCityCommand)
        {
            createCityCommand.CreatedBy = GetApplicationUserClaim(ClaimTypes.Email);
            var result = await mediator.Send(createCityCommand);
            return Ok(result);
        }

        // PUT api/cities/5
        [HttpPut("{cityId}")]
        [Roles(RolesDictionary.Admin)]
        public async Task<IActionResult> UpdateCity(int cityId, [FromBody] UpdateCityCommand updateCityCommand)
        {
            if (cityId != updateCityCommand.Id)
            {
                return BadRequest();
            }

            updateCityCommand.LastModifiedBy = GetApplicationUserClaim(ClaimTypes.Email);
            var result = await mediator.Send(updateCityCommand);
            return Ok(result);
        }

        // DELETE api/cities/5
        [HttpDelete("{cityId}")]
        [Roles(RolesDictionary.Admin)]
        public async Task<IActionResult> DeleteCity(int cityId)
        {
            var command = new DeleteCityCommand(cityId);
            var result = await mediator.Send(command);
            return Ok(result);
        }

        // GET api/cities/5
        [HttpGet("{cityId}")]
        public async Task<IActionResult> GetCity(int cityId)
        {
            var query = new GetCityByIdQuery(cityId);
            var result = await mediator.Send(query);
            return Ok(result);
        }

        // GET api/cities
        [HttpGet]
        public async Task<IActionResult> GetCities([FromQuery] GetCitiesQuery getCitiesQuery)
        {
            var result = await mediator.Send(getCitiesQuery);
            return Ok(result);
        }
    }
}
