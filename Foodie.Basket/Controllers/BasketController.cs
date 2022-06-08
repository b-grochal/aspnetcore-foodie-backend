using Foodie.Basket.Models;
using Foodie.Basket.Repositories.Interfaces;
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
        private readonly IBasketRepository basketRepository;

        public BasketController(IBasketRepository basketRepository)
        {
            this.basketRepository = basketRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetBasket()
        {
            var result = await basketRepository.GetBasket(GetUserId());
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBasket([FromBody] CustomerBasket customerBasket)
        {
            if (GetUserId() != customerBasket.CustomerId)
            {
                return BadRequest();
            }

            var result = await basketRepository.UpdateBasket(customerBasket);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBasket()
        {
            await basketRepository.DeleteBasket(GetUserId());
            return Ok();
        }

        [Route("checkout")]
        //[HttpPost]
        [HttpGet]
        public async Task<ActionResult> CheckoutAsync([FromBody] BasketCheckout basketCheckout)
        {
            //var identityServiceRequest = new GetApplicationUserRequest { Id = request.ApplicationUserId };
            //var call = await identityServiceClient.GetApplicationUserAsync(identityServiceRequest);

            //checkoutBasketCommand.ApplicationUserId = GetUserId();
            //await mediator.Send(checkoutBasketCommand);
            return Ok();
        }

        protected string GetUserId()
        {
            return this.User.Claims.First(i => i.Type == "ApplicationUserId").Value;
        }
    }
}
