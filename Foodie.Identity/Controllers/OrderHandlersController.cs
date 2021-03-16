using Foodie.Identity.Commands.OrderHandlers;
using Foodie.Identity.Queries.OrderHandlers;
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

        // POST api/OrderHandlers
        [HttpPost]
        public async Task<IActionResult> CreateOrderHandler([FromBody] CreateOrderHandlerCommand createOrderHandlerCommand)
        {
            await mediator.Send(createOrderHandlerCommand);
            return Ok();
        }

        // PUT api/OrderHandlers/5
        [HttpPut("{orderHandlerId}")]
        public async Task<IActionResult> EditOrderHandler(string orderHandlerId, [FromBody] EditOrderHandlerCommand editOrderHandlerCommand)
        {
            if (orderHandlerId != editOrderHandlerCommand.Id)
            {
                return BadRequest();
            }

            await mediator.Send(editOrderHandlerCommand);
            return Ok();
        }

        // DELETE api/OrderHandlers/5
        [HttpDelete("{orderHandlerId}")]
        public async Task<IActionResult> DeleteOrderHandler(string orderHandlerId)
        {
            var command = new DeleteOrderHandlerCommand(orderHandlerId);
            await mediator.Send(command);
            return Ok();
        }

        // GET api/OrderHandlers/5
        [HttpGet("{orderHandlerId}")]
        public async Task<IActionResult> GetOrderHandler(string orderHandlerId)
        {
            var query = new GetOrderHandlerByIdQuery(orderHandlerId);
            var result = await mediator.Send(query);
            return Ok(result);
        }

        // GET api/OrderHandlers
        [HttpGet]
        public async Task<IActionResult> GetAllOrderHandlers()
        {
            var query = new GetAllOrderHandlersQuery();
            var result = await mediator.Send(query);
            return Ok(result);
        }
    }
}
