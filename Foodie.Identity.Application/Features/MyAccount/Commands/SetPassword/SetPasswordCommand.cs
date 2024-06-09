using Foodie.Common.Application.Requests.Commands.Interfaces;
using Foodie.Common.Results;
using MediatR;

namespace Foodie.Identity.Application.Features.MyAccount.Commands.SetPassword
{
    public class SetPasswordCommand : IRequest<Result>, IAuditableCommand
    {
        public string SetPasswordToken { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public int ApplicationUserId { get; set; }
        public string ApplicationUserEmail { get; set; }
    }
}
