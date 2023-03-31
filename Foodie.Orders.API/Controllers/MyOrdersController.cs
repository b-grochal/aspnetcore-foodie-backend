using Foodie.Orders.Application.Functions.Orders.Queries.GetCustomersOrderById;
using Foodie.Orders.Application.Functions.Orders.Queries.GetCustomersOrders;
using Foodie.Shared.Authorization;
using Foodie.Shared.Controllers;
using Foodie.Shared.Extensions.Attributes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Foodie.Orders.API.Controllers
{
    [Route("api/my-orders")]
    [ApiController]
    [Roles(RolesDictionary.Customer)]
    public class MyOrdersController : BaseController
    {
        public MyOrdersController(IMediator mediator) : base(mediator) { }

        // GET api/my-orders/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomersOrder(int id)
        {
            var query = new GetCustomersOrderByIdQuery(id, GetApplicationUserClaim(ClaimTypes.NameIdentifier));
            var result = await mediator.Send(query);
            return Ok(result);
        }

        // GET api/my-orders
        [HttpGet]
        public async Task<IActionResult> GetCustomersOrders([FromQuery] GetCustomersOrdersQuery getOrdersQuery)
        {
            getOrdersQuery.CustomerId = GetApplicationUserClaim(ClaimTypes.NameIdentifier);
            var result = await mediator.Send(getOrdersQuery);
            return Ok(result);
        }
    }
}
