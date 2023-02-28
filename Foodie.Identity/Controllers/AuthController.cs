using Foodie.Identity.Application.Functions.Auth.Commands.SignIn;
using Foodie.Identity.Application.Functions.Auth.Commands.SignUp;
using Foodie.Shared.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Foodie.Identity.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : BaseController
    {
        public AuthController(IMediator mediator) : base(mediator) { }

        // POST api/auth/sign-in
        [HttpPost("sign-in")]
        public async Task<IActionResult> SignIn([FromBody] SignInCommand signInCommand)
        {
            var result = await mediator.Send(signInCommand);
            return Ok(result);
        }

        // POST api/auth/sign-up
        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUp([FromBody] SignUpCommand signUpCommand)
        {
            var result = await mediator.Send(signUpCommand);
            return Ok(result);
        }
    }
}
