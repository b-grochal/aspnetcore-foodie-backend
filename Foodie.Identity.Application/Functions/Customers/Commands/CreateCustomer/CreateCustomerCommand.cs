using Foodie.Common.Application.Commands;
using MediatR;

namespace Foodie.Identity.Application.Functions.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommand : AuditableCommand, IRequest<CreateCustomerCommandResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
