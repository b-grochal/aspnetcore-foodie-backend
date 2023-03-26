using Foodie.Basket.Models;
using Foodie.Basket.Repositories.Interfaces;
using Foodie.EventBus.IntegrationEvents.Basket;
using Foodie.Shared.Authorization;
using Foodie.Shared.Controllers;
using Foodie.Shared.Extensions.Attributes;
using IdentityGrpc;
using MassTransit;
using MealsGrpc;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Foodie.Basket.Controllers
{
    [Route("api/my-basket")]
    [Roles(RolesDictionary.Customer)]
    public class MyBasketController : BaseController
    {
        private readonly IBasketRepository basketRepository;
        private readonly IdentityService.IdentityServiceClient identityServiceClient;
        private readonly MealsService.MealsServiceClient mealsServiceClient;
        private readonly IPublishEndpoint publishEndpoint;

        public MyBasketController(IBasketRepository basketRepository, IdentityService.IdentityServiceClient identityServiceClient, MealsService.MealsServiceClient mealsServiceClient, IPublishEndpoint publishEndpoint) : base(null)
        {
            this.basketRepository = basketRepository;
            this.identityServiceClient = identityServiceClient;
            this.mealsServiceClient = mealsServiceClient;
            this.publishEndpoint = publishEndpoint;
        }

        [HttpGet]
        public async Task<IActionResult> GetBasket()
        {
            var result = await basketRepository.GetBasket(GetApplicationUserClaim(ClaimTypes.NameIdentifier));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBasket([FromBody] CustomerBasket customerBasket)
        {
            var result = await basketRepository.UpdateBasket(GetApplicationUserClaim(ClaimTypes.NameIdentifier), customerBasket);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBasket()
        {
            await basketRepository.DeleteBasket(GetApplicationUserClaim(ClaimTypes.NameIdentifier));
            return Ok();
        }

        [Route("checkout")]
        [HttpPost]
        public async Task<ActionResult> CheckoutAsync([FromBody] BasketCheckout basketCheckout)
        {
            var customerId = GetApplicationUserClaim(ClaimTypes.NameIdentifier);
            var basket = await basketRepository.GetBasket(customerId);

            var identityServiceRequest = new GetCustomerRequest { Id = customerId };
            var identityCall = await identityServiceClient.GetCustomerAsync(identityServiceRequest);
            var customer = identityCall.Customer;

            var mealsServiceRequest = new GetLocationRequest { Id = basket.LocationId };
            var mealsCall = await mealsServiceClient.GetLocationAsync(mealsServiceRequest);
            var location = mealsCall.Location;

            await publishEndpoint.Publish<CustomerCheckoutIntegrationEvent>(new
            {
                CustomerId = "6a1ab648-6be8-44f1-87b7-394c34547589",
                CustomerFirstName = customer.FirstName,
                CustomerLastName = customer.LastName,
                CustomerPhoneNumber = customer.PhoneNumber,
                CustomerEmail = customer.Email,
                AddressStreet = basketCheckout.Address,
                AddressCity = location.CityName,
                AddressCountry = location.CityCountry,
                RestaurantId = location.RestaurantId,
                RestaurantName = location.RestaurantName,
                LocationId = location.Id,
                LocationAddress = location.Address,
                LocationPhoneNumber = location.PhoneNumber,
                LocationEmail = location.Email,
                CityId = location.CityId,
                CityName = location.CityName,
                LocationCountry = location.CityCountry,
                OrderItems = basket.Items.Select(i => 
                new 
                {
                   MealId = i.MealId,
                   MealName = i.MealName,
                   UnitPrice = i.UnitPrice,
                   Quantity = i.Quantity
                }) 
            });

            return Ok();
        }
    }
}
