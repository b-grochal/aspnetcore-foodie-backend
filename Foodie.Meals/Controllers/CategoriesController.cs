using Foodie.Common.Api.Authorization;
using Foodie.Common.Api.Controllers;
using Foodie.Common.Enums;
using Foodie.Meals.Application.Functions.Categories.Commands.CreateCategory;
using Foodie.Meals.Application.Functions.Categories.Commands.DeleteCategory;
using Foodie.Meals.Application.Functions.Categories.Commands.UpdateCategory;
using Foodie.Meals.Application.Functions.Categories.Queries.GetCategories;
using Foodie.Meals.Application.Functions.Categories.Queries.GetCategoryById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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
        [RequiredRoles(ApplicationUserRole.Admin)]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand createCategoryCommand)
        {
            createCategoryCommand.User = Email;
            var result = await mediator.Send(createCategoryCommand);
            return Ok(result);
        }

        // PUT api/categories/5
        [HttpPut("{id}")]
        [RequiredRoles(ApplicationUserRole.Admin)]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] UpdateCategoryCommand updateCategoryCommand)
        {
            if (id != updateCategoryCommand.Id)
            {
                return BadRequest();
            }

            updateCategoryCommand.User = Email;
            var result = await mediator.Send(updateCategoryCommand);
            return Ok(result);
        }

        // DELETE api/categories/5
        [HttpDelete("{id}")]
        [RequiredRoles(ApplicationUserRole.Admin)]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var command = new DeleteCategoryCommand(id);
            var result = await mediator.Send(command);
            return Ok(result);
        }

        // GET api/categories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var query = new GetCategoryByIdQuery(id);
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
