using Foodie.Common.Api.Authorization;
using Foodie.Common.Api.Controllers;
using Foodie.Common.Enums;
using Foodie.Orders.Application.Features.Orders.Queries.GetCustomersOrderById;
using Foodie.Orders.Application.Features.Orders.Queries.GetCustomersOrders;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Foodie.Orders.API.Controllers
{
    [Route("api/my-orders")]
    [ApiController]
    [RequiredRoles(ApplicationUserRole.Customer)]
    public class MyOrdersController : BaseController
    {
        public MyOrdersController(IMediator mediator) : base(mediator) { }

        // GET api/my-orders/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomersOrder(int id)
        {
            var query = new GetCustomersOrderByIdQuery(id);
            var result = await mediator.Send(query);
            return Ok(result);
        }

        // GET api/my-orders
        [HttpGet]
        public async Task<IActionResult> GetCustomersOrders([FromQuery] GetCustomersOrdersQuery getOrdersQuery)
        {
            var result = await mediator.Send(getOrdersQuery);
            return Ok(result);
        }
    }
}
