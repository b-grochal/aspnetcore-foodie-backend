using Foodie.Meals.Application.Functions.Restaurants.Commands.CreateRestaurant;
using Foodie.Meals.Application.Functions.Restaurants.Commands.DeleteRestaurant;
using Foodie.Meals.Application.Functions.Restaurants.Commands.UpdateRestaurant;
using Foodie.Meals.Application.Functions.Restaurants.Queries.GetRestaurantById;
using Foodie.Meals.Application.Functions.Restaurants.Queries.GetRestaurantLocations;
using Foodie.Meals.Application.Functions.Restaurants.Queries.GetRestaurantMeals;
using Foodie.Meals.Application.Functions.Restaurants.Queries.GetRestaurants;
using Foodie.Shared.Authorization;
using Foodie.Shared.Controllers;
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
    public class RestaurantsController : BaseController
    {
        public RestaurantsController(IMediator mediator) : base(mediator) { }

        // POST api/restaurants
        [HttpPost]
        [Roles(RolesDictionary.Admin)]
        public async Task<IActionResult> CreateRestaurant([FromBody] CreateRestaurantCommand createRestaurantCommand)
        {
            createRestaurantCommand.CreatedBy = GetApplicationUserClaim(ClaimTypes.Email);
            var result = await mediator.Send(createRestaurantCommand);
            return Ok(result);
        }

        // PUT api/restaurants/5
        [HttpPut("{id}")]
        [Roles(RolesDictionary.Admin)]
        public async Task<IActionResult> UpdateRestaurant(int id, [FromBody] UpdateRestaurantCommand updateRestaurantCommand)
        {
            if (id != updateRestaurantCommand.Id)
            {
                return BadRequest();
            }

            updateRestaurantCommand.LastModifiedBy = GetApplicationUserClaim(ClaimTypes.Email);
            var result = await mediator.Send(updateRestaurantCommand);
            return Ok(result);
        }

        // DELETE api/restaurants/5
        [HttpDelete("{id}")]
        [Roles(RolesDictionary.Admin)]
        public async Task<IActionResult> DeleteRestaurant(int id)
        {
            var command = new DeleteRestaurantCommand(id);
            var result = await mediator.Send(command);
            return Ok(result);
        }

        // GET api/restaurants/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRestaurant(int id)
        {
            var query = new GetRestaurantByIdQuery(id);
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
        [HttpGet("{id}/meals")]
        public async Task<IActionResult> GetRestaurantMeals(int id)
        {
            var query = new GetRestaurantMealsQuery(id);
            var result = await mediator.Send(query);
            return Ok(result);
        }

        // GET api/restaurants/5/locations
        [HttpGet("{id}/locations")]
        public async Task<IActionResult> GetRestaurantLocations(int id, int? cityId)
        {
            var query = new GetRestaurantLocationsQuery(id, cityId);
            var result = await mediator.Send(query);
            return Ok(result);
        }
    }
}
