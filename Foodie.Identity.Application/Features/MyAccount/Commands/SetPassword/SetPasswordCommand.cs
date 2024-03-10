using MediatR;

namespace Foodie.Identity.Application.Functions.MyAccount.Commands.SetPassword
{
    public class SetPasswordCommand : IRequest
    {
        public string SetPasswordToken { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
