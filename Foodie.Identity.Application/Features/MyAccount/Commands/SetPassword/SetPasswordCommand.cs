using Foodie.Common.Application.Requests.Commands.Abstractions;
using Foodie.Common.Results;
using MediatR;

namespace Foodie.Identity.Application.Features.MyAccount.Commands.SetPassword
{
    public class SetPasswordCommand : IRequest<Result>, IAuditableCommand
    {
        public string SetPasswordToken { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string User { get; set; }
    }
}
