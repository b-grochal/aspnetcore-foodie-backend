using Foodie.Common.Api.Authorization;
using Foodie.Common.Api.Controllers;
using Foodie.Common.Enums;
using Foodie.Orders.Application.Features.Orders.Commands.CancelOrder;
using Foodie.Orders.Application.Features.Orders.Commands.SetDeliveredOrderStatus;
using Foodie.Orders.Application.Features.Orders.Commands.SetInDeliveryOrderStatus;
using Foodie.Orders.Application.Features.Orders.Commands.SetInProgressOrderStatus;
using Foodie.Orders.Application.Features.Orders.Queries.GetOrderById;
using Foodie.Orders.Application.Features.Orders.Queries.GetOrders;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Foodie.Orders.API.Controllers
{
    [Route("api/[controller]")]
    [RequiredRoles(ApplicationUserRole.Admin, ApplicationUserRole.OrderHandler)]
    public class OrdersController : BaseController
    {
        public OrdersController(IMediator mediator) : base(mediator) { }

        // PUT api/orders/5/cancel
        [HttpPut("{id}/cancel")]
        public async Task<IActionResult> CancelOrder(int id)
        {
            var command = new CancelOrderCommand(id);

            await mediator.Send(command);
            return Ok();
        }

        // PUT api/orders/5/delivered
        [HttpPut("{id}/delivered")]
        public async Task<IActionResult> SetDeliveredStatus(int id)
        {
            var command = new SetDeliveredOrderStatusCommand(id);

            await mediator.Send(command);
            return Ok();
        }

        // PUT api/orders/5/in-delivery
        [HttpPut("{id}/in-delivery")]
        public async Task<IActionResult> SetInDeliveryStatus(int id)
        {
            var command = new SetInDeliveryOrderStatusCommand(id);

            await mediator.Send(command);
            return Ok();
        }

        // PUT api/orders/5/in-progress
        [HttpPut("{id}/in-progress")]
        public async Task<IActionResult> SetInProgressStatus(int id)
        {
            var command = new SetInProgressOrderStatusCommand(id);

            await mediator.Send(command);
            return Ok();
        }

        // GET api/orders/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var query = new GetOrderByIdQuery(id);

            var result = await mediator.Send(query);
            return Ok(result);
        }

        // GET api/orders
        [HttpGet]
        public async Task<IActionResult> GetOrders([FromQuery] GetOrdersQuery getOrdersQuery)
        {
            var result = await mediator.Send(getOrdersQuery);
            return Ok(result);
        }
    }
}
