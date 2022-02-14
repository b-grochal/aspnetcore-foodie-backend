using Foodie.Basket.Commands;
using Foodie.Basket.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IMediator mediator;

        public BasketController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetBasket()
        {
            var query = new GetBasketByIdQuery(GetUserId());
            var result = await mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBasket([FromBody] UpdateBasketCommand updateBasketCommand)
        {
            if(GetUserId() != updateBasketCommand.UserId)
            {
                return BadRequest();
            }

            await mediator.Send(updateBasketCommand);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBasket()
        {
            var command = new DeleteBasketCommand(GetUserId());
            await mediator.Send(command);
            return Ok();
        }

        [Route("checkout")]
        [HttpPost]
        public async Task<ActionResult> CheckoutAsync([FromBody] CheckoutBasketCommand checkoutBasketCommand)
        {
            throw new NotImplementedException();
        }

        protected string GetUserId()
        {
            return this.User.Claims.First(i => i.Type == "UserId").Value;
        }
    }
}
