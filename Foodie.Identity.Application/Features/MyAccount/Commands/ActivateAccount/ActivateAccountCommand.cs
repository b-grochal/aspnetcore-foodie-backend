using Foodie.Common.Results;
using MediatR;

namespace Foodie.Identity.Application.Features.MyAccount.Commands.ActivateAccount
{
    public class ActivateAccountCommand : IRequest<Result>
    {
        public string AccountActivationToken { get; set; }
    }
}
