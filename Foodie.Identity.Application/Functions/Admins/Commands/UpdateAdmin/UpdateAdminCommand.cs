using Foodie.Shared.Commands;
using MediatR;

namespace Foodie.Identity.Application.Functions.Admins.Commands.UpdateAdmin
{
    public class UpdateAdminCommand : AuditableUpdateCommand, IRequest<UpdateAdminCommandResponse>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
