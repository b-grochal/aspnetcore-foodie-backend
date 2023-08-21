using MediatR;

namespace Foodie.Identity.Application.Functions.MyAccount.Commands.ActivateAccount
{
    public class ActivateAccountCommand : IRequest
    {
        public string AccountActivationToken { get; set; }
    }
}
