using Foodie.Meals.Application.Functions.Meals.Commands.CreateMeal;
using Foodie.Meals.Application.Functions.Meals.Commands.DeleteMeal;
using Foodie.Meals.Application.Functions.Meals.Commands.UpdateMeal;
using Foodie.Meals.Application.Functions.Meals.Queries.GetMealById;
using Foodie.Meals.Application.Functions.Meals.Queries.GetMeals;
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
    public class MealsController : BaseController
    { 
        public MealsController(IMediator mediator) : base(mediator) { }

        // POST api/meals
        [HttpPost]
        [Roles(RolesDictionary.Admin)]
        public async Task<IActionResult> CreateMeal([FromBody] CreateMealCommand createMealCommand)
        {
            createMealCommand.CreatedBy = GetApplicationUserClaim(ClaimTypes.Email);
            var result = await mediator.Send(createMealCommand);
            return Ok(result);
        }

        // PUT api/meals/5
        [HttpPut("{mealId}")]
        [Roles(RolesDictionary.Admin)]
        public async Task<IActionResult> UpdateMeal(int mealId, [FromBody] UpdateMealCommand updateMealCommand)
        {
            if (mealId != updateMealCommand.Id)
            {
                return BadRequest();
            }

            updateMealCommand.LastModifiedBy = GetApplicationUserClaim(ClaimTypes.Email);
            var result = await mediator.Send(updateMealCommand);
            return Ok(result);
        }

        // DELETE api/meals/5
        [HttpDelete("{mealId}")]
        [Roles(RolesDictionary.Admin)]
        public async Task<IActionResult> DeleteMeal(int mealId)
        {
            var command = new DeleteMealCommand(mealId);
            var result = await mediator.Send(command);
            return Ok(result);
        }

        // GET api/meals/5
        [HttpGet("{mealId}")]
        public async Task<IActionResult> GetMeal(int mealId)
        {
            var query = new GetMealByIdQuery(mealId);
            var result = await mediator.Send(query);
            return Ok(result);
        }

        // GET api/meals
        [HttpGet]
        public async Task<IActionResult> GetMeals([FromQuery] GetMealsQuery getMealsQuery)
        {
            var result = await mediator.Send(getMealsQuery);
            return Ok(result);
        }

        private string GetUserEmail()
        {
            return User.FindFirstValue(ClaimTypes.Email);
        }
    }
}
