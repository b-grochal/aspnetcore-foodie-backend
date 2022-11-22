using Foodie.Identity.Application.Functions.OrderHandlers.Commands.CreateOrderHandler;
using Foodie.Identity.Application.Functions.OrderHandlers.Commands.DeleteOrderHandler;
using Foodie.Identity.Application.Functions.OrderHandlers.Commands.UpdateOrderHandler;
using Foodie.Identity.Application.Functions.OrderHandlers.Queries.GetOrderHandlerById;
using Foodie.Identity.Application.Functions.OrderHandlers.Queries.GetOrderHandlers;
using Foodie.Shared.Authorization;
using Foodie.Shared.Extensions.Attributes;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.Identity.Controllers
{
    [Route("api/order-handlers")]
    [ApiController]
    public class OrderHandlersController : ControllerBase
    {
        private readonly IMediator mediator;

        public OrderHandlersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // POST api/order-handlers
        [HttpPost]
        [Roles(RolesDictionary.Admin)]
        public async Task<IActionResult> CreateOrderHandler([FromBody] CreateOrderHandlerCommand createOrderHandlerCommand)
        {
            var result = await mediator.Send(createOrderHandlerCommand);
            return Ok(result);
        }

        // PUT api/order-handlers/5
        [HttpPut("{orderHandlerId}")]
        [Roles(RolesDictionary.Admin)]
        public async Task<IActionResult> UpdateOrderHandler(string orderHandlerId, [FromBody] UpdateOrderHandlerCommand updateOrderHandlerCommand)
        {
            if (orderHandlerId != updateOrderHandlerCommand.OrderHandlerId)
            {
                return BadRequest();
            }

            var result = await mediator.Send(updateOrderHandlerCommand);
            return Ok(result);
        }

        // DELETE api/order-handlers/5
        [HttpDelete("{orderHandlerId}")]
        [Roles(RolesDictionary.Admin)]
        public async Task<IActionResult> DeleteOrderHandler(string orderHandlerId)
        {
            var command = new DeleteOrderHandlerCommand(orderHandlerId);
            var result = await mediator.Send(command);
            return Ok(result);
        }

        // GET api/order-handlers/5
        [HttpGet("{orderHandlerId}")]
        [Roles(RolesDictionary.Admin)]
        public async Task<IActionResult> GetOrderHandler(string orderHandlerId)
        {
            var query = new GetOrderHandlerByIdQuery(orderHandlerId);
            var result = await mediator.Send(query);
            return Ok(result);
        }

        // GET api/order-handlers
        [HttpGet]
        [Roles(RolesDictionary.Admin)]
        public async Task<IActionResult> GetOrderHandlers([FromQuery] GetOrderHandlersQuery getOrderHandlersQuery)
        {
            var result = await mediator.Send(getOrderHandlersQuery);
            return Ok(result);
        }
    }
}
