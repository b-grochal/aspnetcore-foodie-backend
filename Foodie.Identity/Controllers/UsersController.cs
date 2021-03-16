using Foodie.Identity.Commands.Users;
using Foodie.Identity.Queries.Users;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator mediator;

        public UsersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // POST api/Users
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand createUserCommand)
        {
            await mediator.Send(createUserCommand);
            return Ok();
        }

        // PUT api/Users/5
        [HttpPut("{userId}")]
        public async Task<IActionResult> EditUser(string userId, [FromBody] EditUserCommand editUserCommand)
        {
            if (userId != editUserCommand.Id)
            {
                return BadRequest();
            }

            await mediator.Send(editUserCommand);
            return Ok();
        }

        // DELETE api/Users/5
        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            var command = new DeleteUserCommand(userId);
            await mediator.Send(command);
            return Ok();
        }

        // GET api/Users/5
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUser(string userId)
        {
            var query = new GetUserByIdQuery(userId);
            var result = await mediator.Send(query);
            return Ok(result);
        }

        // GET api/Users
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var query = new GetAllUsersQuery();
            var result = await mediator.Send(query);
            return Ok(result);
        }
    }
}
