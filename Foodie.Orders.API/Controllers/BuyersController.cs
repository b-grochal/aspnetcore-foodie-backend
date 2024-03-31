using Foodie.Common.Api.Controllers;
using Foodie.Orders.Application.Features.Buyers.Queries.GetBuyers;
using Foodie.Orders.Application.Functions.Buyers.Queries.GetBuyerById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Foodie.Orders.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyersController : BaseController
    {
        public BuyersController(IMediator mediator) : base(mediator) { }

        // GET api/buyers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBuyer(int id)
        {
            var query = new GetBuyerByIdQuery(id);
            var result = await mediator.Send(query);
            return Ok(result);
        }

        // GET api/buyers
        [HttpGet]
        public async Task<IActionResult> GetBuyers([FromQuery] GetBuyersQuery getBuyersQuery)
        {
            var result = await mediator.Send(getBuyersQuery);
            return Ok(result);
        }
    }
}
