using Foodie.Meals.Application.Functions.Restaurants.Commands.CreateRestaurant;
using Foodie.Meals.Application.Functions.Restaurants.Commands.DeleteRestaurant;
using Foodie.Meals.Application.Functions.Restaurants.Commands.UpdateRestaurant;
using Foodie.Meals.Application.Functions.Restaurants.Queries.GetRestaurantById;
using Foodie.Meals.Application.Functions.Restaurants.Queries.GetRestaurantLocations;
using Foodie.Meals.Application.Functions.Restaurants.Queries.GetRestaurantMeals;
using Foodie.Meals.Application.Functions.Restaurants.Queries.GetRestaurants;
using Foodie.Shared.Authorization;
using Foodie.Shared.Extensions.Attributes;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Foodie.Meals.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly IMediator mediator;

        public RestaurantsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // POST api/restaurants
        [HttpPost]
        [Roles(RolesDictionary.Admin)]
        public async Task<IActionResult> CreateRestaurant([FromBody] CreateRestaurantCommand createRestaurantCommand)
        {
            createRestaurantCommand.CreatedBy = GetUserEmail();
            var result = await mediator.Send(createRestaurantCommand);
            return Ok(result);
        }

        // PUT api/restaurants/5
        [HttpPut("{restaurantId}")]
        [Roles(RolesDictionary.Admin)]
        public async Task<IActionResult> UpdateRestaurant(int restaurantId, [FromBody] UpdateRestaurantCommand updateRestaurantCommand)
        {
            if (restaurantId != updateRestaurantCommand.RestaurantId)
            {
                return BadRequest();
            }

            updateRestaurantCommand.LastModifiedBy = GetUserEmail();
            var result = await mediator.Send(updateRestaurantCommand);
            return Ok(result);
        }

        // DELETE api/restaurants/5
        [HttpDelete("{restaurantId}")]
        [Roles(RolesDictionary.Admin)]
        public async Task<IActionResult> DeleteRestaurant(int restaurantId)
        {
            var command = new DeleteRestaurantCommand(restaurantId);
            var result = await mediator.Send(command);
            return Ok(result);
        }

        // GET api/restaurants/5
        [HttpGet("{restaurantId}")]
        public async Task<IActionResult> GetRestaurant(int restaurantId)
        {
            var query = new GetRestaurantByIdQuery(restaurantId);
            var result = await mediator.Send(query);
            return Ok(result);
        }

        // GET api/restaurants
        [HttpGet]
        public async Task<IActionResult> GetRestaurants([FromQuery] GetRestaurantsQuery getRestaurantsQuery)
        {
            var result = await mediator.Send(getRestaurantsQuery);
            return Ok(result);
        }

        // GET api/restaurants/5/meals
        [HttpGet("{restaurantId}/meals")]
        public async Task<IActionResult> GetRestaurantMeals(int restaurantId)
        {
            var query = new GetRestaurantMealsQuery(restaurantId);
            var result = await mediator.Send(query);
            return Ok(result);
        }

        // GET api/restaurants/5/locations
        [HttpGet("{restaurantId}/locations")]
        public async Task<IActionResult> GetRestaurantLocations(int restaurantId, int? cityId)
        {
            var query = new GetRestaurantLocationsQuery(restaurantId, cityId);
            var result = await mediator.Send(query);
            return Ok(result);
        }

        private string GetUserEmail()
        {
            return User.FindFirstValue(ClaimTypes.Email);
        }
    }
}
