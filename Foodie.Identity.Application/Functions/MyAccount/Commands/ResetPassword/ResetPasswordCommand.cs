using MediatR;

namespace Foodie.Identity.Application.Functions.MyAccount.Commands.ResetPassword
{
    public class ResetPasswordCommand : IRequest
    {
        public string Email { get; set; }
    }
}
