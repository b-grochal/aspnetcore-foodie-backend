using Foodie.Meals.Application.Functions.Cities.Commands.CreateCity;
using Foodie.Meals.Application.Functions.Cities.Commands.DeleteCity;
using Foodie.Meals.Application.Functions.Cities.Commands.UpdateCity;
using Foodie.Meals.Application.Functions.Cities.Queries.GetCities;
using Foodie.Meals.Application.Functions.Cities.Queries.GetCityById;
using Foodie.Shared.Attributes;
using Foodie.Shared.Authorization;
using Foodie.Shared.Controllers;
using Foodie.Shared.Enums;
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
        [RequiredRoles(ApplicationUserRole.Admin)]
        public async Task<IActionResult> CreateCity([FromBody] CreateCityCommand createCityCommand)
        {
            createCityCommand.CreatedBy = Email;
            var result = await mediator.Send(createCityCommand);
            return Ok(result);
        }

        // PUT api/cities/5
        [HttpPut("{id}")]
        [RequiredRoles(ApplicationUserRole.Admin)]
        public async Task<IActionResult> UpdateCity(int id, [FromBody] UpdateCityCommand updateCityCommand)
        {
            if (id != updateCityCommand.Id)
            {
                return BadRequest();
            }

            updateCityCommand.LastModifiedBy = Email;
            var result = await mediator.Send(updateCityCommand);
            return Ok(result);
        }

        // DELETE api/cities/5
        [HttpDelete("{id}")]
        [RequiredRoles(ApplicationUserRole.Admin)]
        public async Task<IActionResult> DeleteCity(int id)
        {
            var command = new DeleteCityCommand(id);
            var result = await mediator.Send(command);
            return Ok(result);
        }

        // GET api/cities/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCity(int id)
        {
            var query = new GetCityByIdQuery(id);
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
