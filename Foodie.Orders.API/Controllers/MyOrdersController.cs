using Foodie.Orders.Application.Functions.Orders.Queries.GetCustomersOrderById;
using Foodie.Orders.Application.Functions.Orders.Queries.GetCustomersOrders;
using Foodie.Shared.Authorization;
using Foodie.Shared.Extensions.Attributes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.Orders.API.Controllers
{
    [Route("api/my-orders")]
    [ApiController]
    [Roles(RolesDictionary.Customer)]
    public class MyOrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MyOrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/my-orders/5
        [HttpGet("{customersOrderId}")]
        public async Task<IActionResult> GetCustomersOrder(int customersOrderId)
        {
            var query = new GetCustomersOrderByIdQuery(customersOrderId, GetUserId());
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // GET api/my-orders
        [HttpGet]
        public async Task<IActionResult> GetCustomersOrders([FromQuery] GetCustomersOrdersQuery getOrdersQuery)
        {
            getOrdersQuery.UserId = GetUserId();
            var result = await _mediator.Send(getOrdersQuery);
            return Ok(result);
        }

        protected string GetUserId()
        {
            return this.User.Claims.FirstOrDefault(i => i.Type == "ApplicationUserId")?.Value;
        }
    }
}
