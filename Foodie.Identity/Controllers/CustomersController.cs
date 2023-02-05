using Foodie.Identity.Application.Functions.Customers.Commands.CreateCustomer;
using Foodie.Identity.Application.Functions.Customers.Commands.DeleteCustomer;
using Foodie.Identity.Application.Functions.Customers.Commands.UpdateCustomer;
using Foodie.Identity.Application.Functions.Customers.Queries.GetCustomerById;
using Foodie.Identity.Application.Functions.Customers.Queries.GetCustomers;
using Foodie.Shared.Authorization;
using Foodie.Shared.Controllers;
using Foodie.Shared.Extensions.Attributes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Foodie.Identity.Controllers
{
    [Route("api/[controller]")]
    [Roles(RolesDictionary.Admin)]
    public class CustomersController : BaseController
    {
        public CustomersController(IMediator mediator) : base(mediator) { }

        // POST api/customers
        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerCommand createCustomerCommand)
        {
            var result = await mediator.Send(createCustomerCommand);
            return Ok(result);
        }

        // PUT api/customers/5
        [HttpPut("{customerId}")]
        public async Task<IActionResult> UpdateCustomer(string customerId, [FromBody] UpdateCustomerCommand updateUserCommand)
        {
            if (customerId != updateUserCommand.CustomerId)
            {
                return BadRequest();
            }

            var result = await mediator.Send(updateUserCommand);
            return Ok(result);
        }

        // DELETE api/customers/5
        [HttpDelete("{customerId}")]
        public async Task<IActionResult> DeleteCustomer(string customerId)
        {
            var command = new DeleteCustomerCommand(customerId);
            var result = await mediator.Send(command);
            return Ok(result);
        }

        // GET api/customers/5
        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetCustomer(string customerId)
        {
            var query = new GetCustomerByIdQuery(customerId);
            var result = await mediator.Send(query);
            return Ok(result);
        }

        // GET api/customers
        [HttpGet]
        public async Task<IActionResult> GetCustomers([FromQuery] GetCustomersQuery getCustomersQuery)
        {
            var result = await mediator.Send(getCustomersQuery);
            return Ok(result);
        }
    }
}
