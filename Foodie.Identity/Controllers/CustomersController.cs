using Foodie.Common.Api.Authorization;
using Foodie.Common.Api.Controllers;
using Foodie.Common.Api.Results;
using Foodie.Common.Enums;
using Foodie.Identity.Application.Functions.Customers.Commands.CreateCustomer;
using Foodie.Identity.Application.Functions.Customers.Commands.DeleteCustomer;
using Foodie.Identity.Application.Functions.Customers.Commands.UpdateCustomer;
using Foodie.Identity.Application.Functions.Customers.Queries.GetCustomerById;
using Foodie.Identity.Application.Functions.Customers.Queries.GetCustomers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Foodie.Identity.Controllers
{
    [Route("api/[controller]")]
    [RequiredRoles(ApplicationUserRole.Admin)]
    public class CustomersController : BaseController
    {
        public CustomersController(IMediator mediator) : base(mediator) { }

        // POST api/customers
        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerCommand createCustomerCommand)
        {
            var result = await mediator.Send(createCustomerCommand);

            return result.Match(
                onSuccess: () => Ok(result.Value),
                onFailure: HandleFailure);
        }

        // PUT api/customers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] UpdateCustomerCommand updateUserCommand)
        {
            if (id != updateUserCommand.Id)
            {
                return BadRequest();
            }

            var result = await mediator.Send(updateUserCommand);

            return result.Match(
                onSuccess: () => Ok(result.Value),
                onFailure: HandleFailure);
        }

        // DELETE api/customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var command = new DeleteCustomerCommand(id);
            var result = await mediator.Send(command);

            return result.Match(
                onSuccess: () => Ok(result.Value),
                onFailure: HandleFailure);
        }

        // GET api/customers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            var query = new GetCustomerByIdQuery(id);
            var result = await mediator.Send(query);

            return result.Match(
                onSuccess: () => Ok(result.Value),
                onFailure: HandleFailure);
        }

        // GET api/customers
        [HttpGet]
        public async Task<IActionResult> GetCustomers([FromQuery] GetCustomersQuery getCustomersQuery)
        {
            var result = await mediator.Send(getCustomersQuery);

            return result.Match(
                onSuccess: () => Ok(result.Value),
                onFailure: HandleFailure);
        }
    }
}
