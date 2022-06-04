using Foodie.Identity.Application.Functions.Auth.Commands.SignIn;
using Foodie.Identity.Application.Functions.Auth.Commands.SignUp;
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
    public class AuthController : ControllerBase
    {
        private readonly IMediator mediator;

        public AuthController(IMediator mediator)
        {
            this.mediator = mediator;
        }

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
