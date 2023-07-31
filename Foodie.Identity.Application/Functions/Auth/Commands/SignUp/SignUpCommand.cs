using Foodie.Shared.Commands;
using MediatR;

namespace Foodie.Identity.Application.Functions.Auth.Commands.SignUp
{
    public class SignUpCommand : AuditableCreateCommand, IRequest<SignUpCommandResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
