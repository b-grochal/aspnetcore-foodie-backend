using Foodie.Common.Api.Authorization;
using Foodie.Common.Api.Controllers;
using Foodie.Common.Enums;
using Foodie.Common.Api.Results;
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

            var result = await mediator.Send(command);

            return result.Match(
                onSuccess: Ok,
                onFailure: HandleFailure);
        }

        // PUT api/orders/5/delivered
        [HttpPut("{id}/delivered")]
        public async Task<IActionResult> SetDeliveredStatus(int id)
        {
            var command = new SetDeliveredOrderStatusCommand(id);

            var result = await mediator.Send(command);

            return result.Match(
                onSuccess: Ok,
                onFailure: HandleFailure);
        }

        // PUT api/orders/5/in-delivery
        [HttpPut("{id}/in-delivery")]
        public async Task<IActionResult> SetInDeliveryStatus(int id)
        {
            var command = new SetInDeliveryOrderStatusCommand(id);

            var result = await mediator.Send(command);

            return result.Match(
                onSuccess: Ok,
                onFailure: HandleFailure);
        }

        // PUT api/orders/5/in-progress
        [HttpPut("{id}/in-progress")]
        public async Task<IActionResult> SetInProgressStatus(int id)
        {
            var command = new SetInProgressOrderStatusCommand(id);

            var result = await mediator.Send(command);

            return result.Match(
                onSuccess: Ok,
                onFailure: HandleFailure);
        }

        // GET api/orders/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var query = new GetOrderByIdQuery(id);

            var result = await mediator.Send(query);

            return result.Match(
                onSuccess: () => Ok(result.Value),
                onFailure: HandleFailure);
        }

        // GET api/orders
        [HttpGet]
        public async Task<IActionResult> GetOrders([FromQuery] GetOrdersQuery getOrdersQuery)
        {
            var result = await mediator.Send(getOrdersQuery);

            return result.Match(
                onSuccess: () => Ok(result.Value),
                onFailure: HandleFailure);
        }
    }
}
