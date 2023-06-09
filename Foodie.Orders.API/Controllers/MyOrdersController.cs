using Foodie.Orders.Application.Functions.Orders.Queries.GetCustomersOrderById;
using Foodie.Orders.Application.Functions.Orders.Queries.GetCustomersOrders;
using Foodie.Shared.Attributes;
using Foodie.Shared.Controllers;
using Foodie.Shared.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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
            var query = new GetCustomersOrderByIdQuery(id, ApplicationUserId.Value);
            var result = await mediator.Send(query);
            return Ok(result);
        }

        // GET api/my-orders
        [HttpGet]
        public async Task<IActionResult> GetCustomersOrders([FromQuery] GetCustomersOrdersQuery getOrdersQuery)
        {
            getOrdersQuery.CustomerId = ApplicationUserId.Value;
            var result = await mediator.Send(getOrdersQuery);
            return Ok(result);
        }
    }
}
