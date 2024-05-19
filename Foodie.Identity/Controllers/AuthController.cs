using Foodie.Common.Api.Controllers;
using Foodie.Common.Api.Results;
using Foodie.Common.Results;
using Foodie.Identity.Application.Features.Auth.Commands.RefreshJwtToken;
using Foodie.Identity.Application.Features.Auth.Commands.RevokeRefreshToken;
using Foodie.Identity.Application.Features.Auth.Commands.SignIn;
using Foodie.Identity.Application.Features.Auth.Commands.SignUp;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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

            return result.Match(
                onSuccess: () => Ok(result.Value),
                onFailure: HandleFailure);
        }

        // POST api/auth/sign-up
        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUp([FromBody] SignUpCommand signUpCommand)
        {
            var result = await mediator.Send(signUpCommand);

            return result.Match(
                onSuccess: () => Ok(result.Value),
                onFailure: HandleFailure);
        }

        // POST api/auth/refresh-jwt-token
        [HttpPost("refresh-jwt-token")]
        public async Task<IActionResult> RefreshJwtToken([FromBody] RefreshJwtTokenCommand refreshJwtTokenCommand)
        {
            var result = await mediator.Send(refreshJwtTokenCommand);

            return result.Match(
                onSuccess: () => Ok(result.Value),
                onFailure: HandleFailure);
        }

        [Authorize]
        [HttpPost("revoke-refresh-token")]
        public async Task<IActionResult> RevokeRefreshToken()
        {
            var result = await mediator.Send(new RevokeRefreshTokenCommand());
            
            return result.Match(
                onSuccess: NoContent,
                onFailure: HandleFailure);
        }
    }
}
