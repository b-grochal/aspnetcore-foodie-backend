using Foodie.Meals.Commands.Restaurants;
using Foodie.Meals.Queries.Restaurants;
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

        // POST api/Restaurants
        [HttpPost]
        public async Task<IActionResult> CreateRestaurant([FromBody] CreateRestaurantCommand createRestaurantCommand)
        {
            await mediator.Send(createRestaurantCommand);
            return Ok();
        }

        // PUT api/Restaurants/5
        [HttpPut("{restaurantId}")]
        public async Task<IActionResult> EditRestaurant(int mealId, [FromBody] EditRestaurantCommand editRestaurantCommand)
        {
            if (mealId != editRestaurantCommand.RestaurantId)
            {
                return BadRequest();
            }

            await mediator.Send(editRestaurantCommand);
            return Ok();
        }

        // DELETE api/Restaurants/5
        [HttpDelete("{restaurantId}")]
        public async Task<IActionResult> DeleteRestaurant(int restaurantId)
        {
            var command = new DeleteRestaurantCommand(restaurantId);
            await mediator.Send(command);
            return Ok();
        }

        // GET api/Restaurants/5
        [HttpGet("{restaurantId}")]
        public async Task<IActionResult> GetRestaurant(int restaurantId)
        {
            var query = new GetRestaurantByIdQuery(restaurantId);
            var result = await mediator.Send(query);
            return Ok(result);
        }

        // GET api/Restaurants
        [HttpGet]
        public async Task<IActionResult> GetAllRestaurants()
        {
            var query = new GetAllRestaurantsQuery();
            var result = await mediator.Send(query);
            return Ok(result);
        }
    }
}
