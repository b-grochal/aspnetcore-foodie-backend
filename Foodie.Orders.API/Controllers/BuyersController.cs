using Foodie.Orders.Application.Functions.Buyers.Queries.GetBuyerById;
using Foodie.Orders.Application.Functions.Buyers.Queries.GetBuyers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Foodie.Orders.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BuyersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/buyers/5
        [HttpGet("{buyerId}")]
        public async Task<IActionResult> GetBuyer(int buyerId)
        {
            var query = new GetBuyerByIdQuery(buyerId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // GET api/buyers
        [HttpGet]
        public async Task<IActionResult> GetBuyers([FromQuery] GetBuyersQuery getBuyersQuery)
        {
            var result = await _mediator.Send(getBuyersQuery);
            return Ok(result);
        }
    }
}
