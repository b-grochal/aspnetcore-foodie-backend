using Foodie.Common.Api.Authorization;
using Foodie.Common.Enums;
using Foodie.Identity.Application.Functions.Customers.Commands.CreateCustomer;
using Foodie.Identity.Application.Functions.Customers.Commands.DeleteCustomer;
using Foodie.Identity.Application.Functions.Customers.Commands.UpdateCustomer;
using Foodie.Identity.Application.Functions.Customers.Queries.GetCustomerById;
using Foodie.Identity.Application.Functions.Customers.Queries.GetCustomers;
using Foodie.Shared.Controllers;
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
            createCustomerCommand.User = Email;
            var result = await mediator.Send(createCustomerCommand);
            return Ok(result);
        }

        // PUT api/customers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] UpdateCustomerCommand updateUserCommand)
        {
            if (id != updateUserCommand.Id)
            {
                return BadRequest();
            }

            updateUserCommand.User = Email;
            var result = await mediator.Send(updateUserCommand);
            return Ok(result);
        }

        // DELETE api/customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var command = new DeleteCustomerCommand(id);
            var result = await mediator.Send(command);
            return Ok(result);
        }

        // GET api/customers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            var query = new GetCustomerByIdQuery(id);
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
