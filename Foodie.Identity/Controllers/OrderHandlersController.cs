using Foodie.Common.Api.Authorization;
using Foodie.Common.Api.Controllers;
using Foodie.Common.Enums;
using Foodie.Identity.Application.Functions.OrderHandlers.Commands.CreateOrderHandler;
using Foodie.Identity.Application.Functions.OrderHandlers.Commands.DeleteOrderHandler;
using Foodie.Identity.Application.Functions.OrderHandlers.Commands.UpdateOrderHandler;
using Foodie.Identity.Application.Functions.OrderHandlers.Queries.GetOrderHandlerById;
using Foodie.Identity.Application.Functions.OrderHandlers.Queries.GetOrderHandlers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Foodie.Identity.Controllers
{
    [Route("api/order-handlers")]
    [RequiredRoles(ApplicationUserRole.Admin)]
    public class OrderHandlersController : BaseController
    {
        public OrderHandlersController(IMediator mediator) : base(mediator) { }

        // POST api/order-handlers
        [HttpPost]
        public async Task<IActionResult> CreateOrderHandler([FromBody] CreateOrderHandlerCommand createOrderHandlerCommand)
        {
            createOrderHandlerCommand.User = Email;
            var result = await mediator.Send(createOrderHandlerCommand);
            return Ok(result);
        }

        // PUT api/order-handlers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrderHandler(int id, [FromBody] UpdateOrderHandlerCommand updateOrderHandlerCommand)
        {
            if (id != updateOrderHandlerCommand.Id)
            {
                return BadRequest();
            }

            updateOrderHandlerCommand.User = Email;
            var result = await mediator.Send(updateOrderHandlerCommand);
            return Ok(result);
        }

        // DELETE api/order-handlers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderHandler(int id)
        {
            var command = new DeleteOrderHandlerCommand(id);
            var result = await mediator.Send(command);
            return Ok(result);
        }

        // GET api/order-handlers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderHandler(int id)
        {
            var query = new GetOrderHandlerByIdQuery(id);
            var result = await mediator.Send(query);
            return Ok(result);
        }

        // GET api/order-handlers
        [HttpGet]
        public async Task<IActionResult> GetOrderHandlers([FromQuery] GetOrderHandlersQuery getOrderHandlersQuery)
        {
            var result = await mediator.Send(getOrderHandlersQuery);
            return Ok(result);
        }
    }
}
