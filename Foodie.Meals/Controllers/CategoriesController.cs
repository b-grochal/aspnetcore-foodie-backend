using Foodie.Meals.Application.Functions.Categories.Commands.CreateCategory;
using Foodie.Meals.Application.Functions.Categories.Commands.DeleteCategory;
using Foodie.Meals.Application.Functions.Categories.Commands.UpdateCategory;
using Foodie.Meals.Application.Functions.Categories.Queries.GetCategories;
using Foodie.Meals.Application.Functions.Categories.Queries.GetCategoryById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Foodie.Meals.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : Controller
    {
        private readonly IMediator mediator;

        public CategoriesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // POST api/categories
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand createCategoryCommand)
        {
            createCategoryCommand.CreatedBy = GetUserEmail();
            await mediator.Send(createCategoryCommand);
            return Ok();
        }

        // PUT api/categories/5
        [HttpPut("{categoryId}")]
        public async Task<IActionResult> UpdateCategory(int categoryId, [FromBody] UpdateCategoryCommand updateCategoryCommand)
        {
            if (categoryId != updateCategoryCommand.CategoryId)
            {
                return BadRequest();
            }

            updateCategoryCommand.LastModifiedBy = GetUserEmail();
            await mediator.Send(updateCategoryCommand);
            return Ok();
        }

        // DELETE api/categories/5
        [HttpDelete("{categoryId}")]
        public async Task<IActionResult> DeleteCategory(int categoryId)
        {
            var command = new DeleteCategoryCommand(categoryId);
            await mediator.Send(command);
            return Ok();
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

        private string GetUserEmail()
        {
            return User.FindFirstValue(ClaimTypes.Email);
        }
    }
}
