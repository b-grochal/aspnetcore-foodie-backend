using Foodie.Common.Domain.Results;
using MediatR;

namespace Foodie.Identity.Application.Features.MyAccount.Commands.ResetPassword
{
    public class ResetPasswordCommand : IRequest<Result>
    {
        public string Email { get; set; }
    }
}
