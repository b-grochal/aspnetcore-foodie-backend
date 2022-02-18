using Foodie.Basket.Commands;
using Foodie.Basket.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
    //[Authorize(Roles ="User")]
    [Authorize]
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
            //var query = new GetBasketByIdQuery(GetUserId());
            //var result = await mediator.Send(query);
            //return Ok(result);
            var command = new CheckoutBasketCommand();
            command.ApplicationUserId = GetUserId();
            await mediator.Send(command);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBasket([FromBody] UpdateBasketCommand updateBasketCommand)
        {
            if (GetUserId() != updateBasketCommand.UserId)
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
        //[HttpPost]
        [HttpGet]
        public async Task<ActionResult> CheckoutAsync([FromBody] CheckoutBasketCommand checkoutBasketCommand)
        {
            checkoutBasketCommand.ApplicationUserId = GetUserId();
            await mediator.Send(checkoutBasketCommand);
            return Ok();
        }

        protected string GetUserId()
        {
            return this.User.Claims.First(i => i.Type == "ApplicationUserId").Value;
        }
    }
}
