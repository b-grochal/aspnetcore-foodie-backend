using Foodie.Basket.Models;
using Foodie.Basket.Repositories.Interfaces;
using IdentityGrpc;
using MealsGrpc;
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
    //[Authorize]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository basketRepository;
        private readonly IdentityService.IdentityServiceClient identityServiceClient;
        private readonly MealsService.MealsServiceClient mealsServiceClient;

        public BasketController(IBasketRepository basketRepository, IdentityService.IdentityServiceClient identityServiceClient, MealsService.MealsServiceClient mealsServiceClient)
        {
            this.basketRepository = basketRepository;
            this.identityServiceClient = identityServiceClient;
            this.mealsServiceClient = mealsServiceClient;
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
        //[HttpPost] + method should have parameter: [FromBody] BasketCheckout basketCheckout
        [HttpGet]
        public async Task<ActionResult> CheckoutAsync()
        {
            //var identityServiceRequest = new GetCustomerRequest { Id = "6a1ab648-6be8-44f1-87b7-394c34547589" };
            //var call = identityServiceClient.GetCustomer(identityServiceRequest);

            var mealsServiceRequest = new GetLocationRequest { Id = 1 };
            var call = await mealsServiceClient.GetLocationAsync(mealsServiceRequest);

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
