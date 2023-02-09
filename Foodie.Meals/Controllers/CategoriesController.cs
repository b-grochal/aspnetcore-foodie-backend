using Foodie.Meals.Application.Functions.Categories.Commands.CreateCategory;
using Foodie.Meals.Application.Functions.Categories.Commands.DeleteCategory;
using Foodie.Meals.Application.Functions.Categories.Commands.UpdateCategory;
using Foodie.Meals.Application.Functions.Categories.Queries.GetCategories;
using Foodie.Meals.Application.Functions.Categories.Queries.GetCategoryById;
using Foodie.Shared.Authorization;
using Foodie.Shared.Controllers;
using Foodie.Shared.Extensions.Attributes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Foodie.Meals.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : BaseController
    {
        public CategoriesController(IMediator mediator) : base(mediator) { }

        // POST api/categories
        [HttpPost]
        [Roles(RolesDictionary.Admin)]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand createCategoryCommand)
        {
            createCategoryCommand.CreatedBy = GetApplicationUserClaim(ClaimTypes.Email);
            var result = await mediator.Send(createCategoryCommand);
            return Ok(result);
        }

        // PUT api/categories/5
        [HttpPut("{categoryId}")]
        [Roles(RolesDictionary.Admin)]
        public async Task<IActionResult> UpdateCategory(int categoryId, [FromBody] UpdateCategoryCommand updateCategoryCommand)
        {
            if (categoryId != updateCategoryCommand.CategoryId)
            {
                return BadRequest();
            }

            updateCategoryCommand.LastModifiedBy = GetApplicationUserClaim(ClaimTypes.Email);
            var result = await mediator.Send(updateCategoryCommand);
            return Ok(result);
        }

        // DELETE api/categories/5
        [HttpDelete("{categoryId}")]
        [Roles(RolesDictionary.Admin)]
        public async Task<IActionResult> DeleteCategory(int categoryId)
        {
            var command = new DeleteCategoryCommand(categoryId);
            var result = await mediator.Send(command);
            return Ok(result);
        }

        // GET api/categories/5
        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetCategory(int categoryId)
        {
            var query = new GetCategoryByIdQuery(categoryId);
            var result = await mediator.Send(query);
            return Ok(result);
        }

        // GET api/categories
        [HttpGet]
        public async Task<IActionResult> GetCategories([FromQuery] GetCategoriesQuery getCategoriesQuery)
        {
            var result = await mediator.Send(getCategoriesQuery);
            return Ok(result);
        }
    }
}
