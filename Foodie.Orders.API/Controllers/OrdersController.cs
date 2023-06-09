using Foodie.Orders.Application.Functions.Orders.Commands.CancelOrder;
using Foodie.Orders.Application.Functions.Orders.Commands.SetDeliveredOrderStatus;
using Foodie.Orders.Application.Functions.Orders.Commands.SetInDeliveryOrderStatus;
using Foodie.Orders.Application.Functions.Orders.Commands.SetInProgressOrderStatus;
using Foodie.Orders.Application.Functions.Orders.Queries.GetOrderById;
using Foodie.Orders.Application.Functions.Orders.Queries.GetOrders;
using Foodie.Shared.Attributes;
using Foodie.Shared.Authentication;
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
    [RequiredRoles(ApplicationUserRole.Admin, ApplicationUserRole.OrderHandler)]
    public class OrdersController : BaseController
    {
        public OrdersController(IMediator mediator) : base(mediator) { }

        // PUT api/orders/5/cancel
        [HttpPut("{id}/cancel")]
        public async Task<IActionResult> CancelOrder(int id)
        {
            var command = new CancelOrderCommand(id);

            if (Role == ApplicationUserRole.OrderHandler)
                command.LocationId = LocationId;

            await mediator.Send(command);
            return Ok();
        }

        // PUT api/orders/5/delivered
        [HttpPut("{id}/delivered")]
        public async Task<IActionResult> SetDeliveredStatus(int id)
        {
            var command = new SetDeliveredOrderStatusCommand(id);

            if (Role == ApplicationUserRole.OrderHandler)
                command.LocationId = LocationId;

            await mediator.Send(command);
            return Ok();
        }

        // PUT api/orders/5/in-delivery
        [HttpPut("{id}/in-delivery")]
        public async Task<IActionResult> SetInDeliveryStatus(int id)
        {
            var command = new SetInDeliveryOrderStatusCommand(id);

            if (Role == ApplicationUserRole.OrderHandler)
                command.LocationId = LocationId;

            await mediator.Send(command);
            return Ok();
        }

        // PUT api/orders/5/in-progress
        [HttpPut("{id}/in-progress")]
        public async Task<IActionResult> SetInProgressStatus(int id)
        {
            var command = new SetInProgressOrderStatusCommand(id);

            if (Role == ApplicationUserRole.OrderHandler)
                command.LocationId = LocationId;

            await mediator.Send(command);
            return Ok();
        }

        // GET api/orders/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var query = new GetOrderByIdQuery(id);

            if (Role == ApplicationUserRole.OrderHandler)
                query.LocationId = LocationId;

            var result = await mediator.Send(query);
            return Ok(result);
        }

        // GET api/orders
        [HttpGet]
        public async Task<IActionResult> GetOrders([FromQuery] GetOrdersQuery getOrdersQuery)
        {
            if (Role == ApplicationUserRole.OrderHandler)
                getOrdersQuery.LocationId = LocationId;

            var result = await mediator.Send(getOrdersQuery);
            return Ok(result);
        }
    }
}
