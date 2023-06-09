using Foodie.Identity.Application.Functions.OrderHandlers.Commands.CreateOrderHandler;
using Foodie.Identity.Application.Functions.OrderHandlers.Commands.DeleteOrderHandler;
using Foodie.Identity.Application.Functions.OrderHandlers.Commands.UpdateOrderHandler;
using Foodie.Identity.Application.Functions.OrderHandlers.Queries.GetOrderHandlerById;
using Foodie.Identity.Application.Functions.OrderHandlers.Queries.GetOrderHandlers;
using Foodie.Shared.Attributes;
using Foodie.Shared.Authorization;
using Foodie.Shared.Controllers;
using Foodie.Shared.Enums;
using Foodie.Shared.Extensions.Attributes;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
            createOrderHandlerCommand.CreatedBy = Email;
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

            updateOrderHandlerCommand.LastModifiedBy = Email;
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
