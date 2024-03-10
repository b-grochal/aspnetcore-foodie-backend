using MediatR;

namespace Foodie.Identity.Application.Functions.Auth.Commands.SignIn
{
    public class SignInCommand : IRequest<SignInCommandResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
