using Foodie.Common.Results;
using MediatR;

namespace Foodie.Identity.Application.Features.MyAccount.Commands.SetPassword
{
    public class SetPasswordCommand : IRequest<Result>
    {
        public string SetPasswordToken { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
