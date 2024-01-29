using Foodie.Common.Application.Commands;
using MediatR;

namespace Foodie.Identity.Application.Functions.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommand : AuditableCommand, IRequest<UpdateCustomerCommandResponse>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
