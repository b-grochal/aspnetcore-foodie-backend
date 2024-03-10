using Foodie.Common.Domain.Results;
using MediatR;

namespace Foodie.Identity.Application.Features.Auth.Commands.SignIn
{
    public class SignInCommand : IRequest<Result<SignInCommandResponse>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
