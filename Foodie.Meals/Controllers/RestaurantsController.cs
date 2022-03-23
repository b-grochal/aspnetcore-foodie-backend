using Foodie.Meals.Application.Functions.Restaurants.Commands.CreateRestaurant;
using Foodie.Meals.Application.Functions.Restaurants.Commands.DeleteRestaurant;
using Foodie.Meals.Application.Functions.Restaurants.Commands.UpdateRestaurant;
using Foodie.Meals.Application.Functions.Restaurants.Queries.GetRestaurantById;
using Foodie.Meals.Application.Functions.Restaurants.Queries.GetRestaurants;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<IActionResult> CreateRestaurant([FromBody] CreateRestaurantCommand createRestaurantCommand)
        {
            await mediator.Send(createRestaurantCommand);
            return Ok();
        }

        // PUT api/restaurants/5
        [HttpPut("{restaurantId}")]
        public async Task<IActionResult> UpdateRestaurant(int restaurantId, [FromBody] UpdateRestaurantCommand updateRestaurantCommand)
        {
            if (restaurantId != updateRestaurantCommand.RestaurantId)
            {
                return BadRequest();
            }

            await mediator.Send(updateRestaurantCommand);
            return Ok();
        }

        // DELETE api/restaurants/5
        [HttpDelete("{restaurantId}")]
        public async Task<IActionResult> DeleteRestaurant(int restaurantId)
        {
            var command = new DeleteRestaurantCommand(restaurantId);
            await mediator.Send(command);
            return Ok();
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
    }
}
