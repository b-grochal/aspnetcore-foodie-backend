using Foodie.Orders.Application.Functions.Orders.Commands.CancelOrder;
using Foodie.Orders.Application.Functions.Orders.Commands.SetDeliveredOrderStatus;
using Foodie.Orders.Application.Functions.Orders.Commands.SetInDeliveryOrderStatus;
using Foodie.Orders.Application.Functions.Orders.Commands.SetInProgressOrderStatus;
using Foodie.Orders.Application.Functions.Orders.Queries.GetOrderById;
using Foodie.Orders.Application.Functions.Orders.Queries.GetOrders;
using Foodie.Shared.Authorization;
using Foodie.Shared.Controllers;
using Foodie.Shared.Enums;
using Foodie.Shared.Extensions.Attributes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Foodie.Orders.API.Controllers
{
    [Route("api/[controller]")]
    [Roles(RolesDictionary.Admin, RolesDictionary.OrderHandler)]
    public class OrdersController : BaseController
    {
        public OrdersController(IMediator mediator) : base(mediator) { }

        // PUT api/orders/5/cancel
        [HttpPut("{orderId}/cancel")]
        public async Task<IActionResult> CancelOrder(int orderId)
        {
            var command = new CancelOrderCommand(orderId);
            await mediator.Send(command);
            return Ok();
        }

        // PUT api/orders/5/delivered
        [HttpPut("{orderId}/delivered")]
        public async Task<IActionResult> SetDeliveredStatus(int orderId)
        {
            var command = new SetDeliveredOrderStatusCommand(orderId);
            await mediator.Send(command);
            return Ok();
        }

        // PUT api/orders/5/in-delivery
        [HttpPut("{orderId}/in-delivery")]
        public async Task<IActionResult> SetInDeliveryStatus(int orderId)
        {
            var command = new SetInDeliveryOrderStatusCommand(orderId);
            await mediator.Send(command);
            return Ok();
        }

        // PUT api/orders/5/in-progress
        [HttpPut("{orderId}/in-progress")]
        public async Task<IActionResult> SetInProgressStatus(int orderId)
        {
            var command = new SetInProgressOrderStatusCommand(orderId);
            await mediator.Send(command);
            return Ok();
        }

        // GET api/orders/5
        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrder(int orderId)
        {
            var query = new GetOrderByIdQuery(orderId); 
            var result = await mediator.Send(query);
            return Ok(result);
        }

        // GET api/orders
        [HttpGet]
        public async Task<IActionResult> GetOrders([FromQuery] GetOrdersQuery getOrdersQuery)
        {
            if (GetApplicationUserClaim(ApplicationUserClaims.Role) == RolesDictionary.OrderHandler)
                getOrdersQuery.LocationId = int.Parse(GetApplicationUserClaim(ApplicationUserClaims.LocationId));

            var result = await mediator.Send(getOrdersQuery);
            return Ok(result);
        }
    }
}
