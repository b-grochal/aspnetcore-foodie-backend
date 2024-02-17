using Foodie.Common.Api.Authorization;
using Foodie.Common.Api.Controllers;
using Foodie.Common.Enums;
using Foodie.Meals.Application.Functions.Countries.Commands.CreateCountry;
using Foodie.Meals.Application.Functions.Countries.Commands.DeleteCountry;
using Foodie.Meals.Application.Functions.Countries.Commands.UpdateCountry;
using Foodie.Meals.Application.Functions.Countries.Queries.GetCountries;
using Foodie.Meals.Application.Functions.Countries.Queries.GetCountryById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Foodie.Meals.API.Controllers
{
    [Route("api/[controller]")]
    public class CountriesController : BaseController
    {
        public CountriesController(IMediator mediator) : base(mediator) { }

        // POST api/countries
        [HttpPost]
        [RequiredRoles(ApplicationUserRole.Admin)]
        public async Task<IActionResult> CreateCountry([FromBody] CreateCountryCommand createCountryCommand)
        {
            createCountryCommand.User = Email;
            var result = await mediator.Send(createCountryCommand);
            return Ok(result);
        }

        // PUT api/countries/5
        [HttpPut("{id}")]
        [RequiredRoles(ApplicationUserRole.Admin)]
        public async Task<IActionResult> UpdateCountry(int id, [FromBody] UpdateCountryCommand updateCountryCommand)
        {
            if (id != updateCountryCommand.Id)
            {
                return BadRequest();
            }

            updateCountryCommand.User = Email;
            var result = await mediator.Send(updateCountryCommand);
            return Ok(result);
        }

        // DELETE api/country/5
        [HttpDelete("{id}")]
        [RequiredRoles(ApplicationUserRole.Admin)]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var command = new DeleteCountryCommand(id);
            var result = await mediator.Send(command);
            return Ok(result);
        }

        // GET api/countries/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCountry(int id)
        {
            var query = new GetCountryByIdQuery(id);
            var result = await mediator.Send(query);
            return Ok(result);
        }

        // GET api/countires
        [HttpGet]
        public async Task<IActionResult> GetCountries([FromQuery] GetCountriesQuery getCountriesQuery)
        {
            var result = await mediator.Send(getCountriesQuery);
            return Ok(result);
        }
    }
}
