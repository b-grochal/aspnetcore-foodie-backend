using Foodie.Basket.Models;
using Foodie.Basket.Repositories.Interfaces;
using Foodie.EventBus.IntegrationEvents.Basket;
using IdentityGrpc;
using MassTransit;
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
        private readonly IPublishEndpoint publishEndpoint;

        public BasketController(IBasketRepository basketRepository, IdentityService.IdentityServiceClient identityServiceClient, MealsService.MealsServiceClient mealsServiceClient, IPublishEndpoint publishEndpoint)
        {
            this.basketRepository = basketRepository;
            this.identityServiceClient = identityServiceClient;
            this.mealsServiceClient = mealsServiceClient;
            this.publishEndpoint = publishEndpoint;
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
            var identityservicerequest = new GetCustomerRequest { Id = "6a1ab648-6be8-44f1-87b7-394c34547589" };
            var identityCall = await identityServiceClient.GetCustomerAsync(identityservicerequest);
            var customer = identityCall.Customer;

            var mealsServiceRequest = new GetLocationRequest { Id = 1 };
            var mealsCall = await mealsServiceClient.GetLocationAsync(mealsServiceRequest);
            var location = mealsCall.Location;

            var basketItems = new List<BasketItem>
            {
                new BasketItem 
                { 
                    BasketItemId = 1, 
                    MealId = 1, 
                    MealName = "Cheesburger",
                    Quantity = 1,
                    UnitPrice = 123
                },
                new BasketItem
                {
                    BasketItemId = 2,
                    MealId = 2,
                    MealName = "Big Mac",
                    Quantity = 1,
                    UnitPrice = 123
                },
                new BasketItem
                {
                    BasketItemId = 3,
                    MealId = 3,
                    MealName = "Apple juice",
                    Quantity = 1,
                    UnitPrice = 123
                }
            };

            await publishEndpoint.Publish<CustomerCheckoutIntegrationEvent>(new
            {
                UserId = "6a1ab648-6be8-44f1-87b7-394c34547589",
                UserFirstName = customer.FirstName,
                UserLastName = customer.LastName,
                UserPhoneNumber = customer.PhoneNumber,
                UserEmail = customer.Email,
                AddressStreet = "TEST ADDRESS", //
                AddressCity = location.CityName,
                AddressCountry = location.CityCountry,
                RestaurantId = location.RestaurantId,
                RestaurantName = location.RestaurantName,
                LocationId = location.LocationId,
                LocationAddress = location.Address,
                LocationPhoneNumber = location.PhoneNumber,
                LocationEmail = location.Email,
                CityId = location.CityId,
                CityName = location.CityName,
                LocationCountry = location.CityCountry,
                OrderItems = basketItems.Select(i => 
                new 
                {
                   MealId = i.MealId,
                   MealName = i.MealName,
                   UnitPrice = i.UnitPrice,
                   Quantity = i.Quantity
                }) 
            });

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
