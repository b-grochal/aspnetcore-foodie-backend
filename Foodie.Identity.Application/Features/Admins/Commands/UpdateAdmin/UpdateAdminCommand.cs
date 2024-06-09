using Foodie.Common.Application.Requests.Commands.Interfaces;
using Foodie.Common.Results;
using MediatR;

namespace Foodie.Identity.Application.Functions.Admins.Commands.UpdateAdmin
{
    public class UpdateAdminCommand : IAuditableCommand, IRequest<Result<UpdateAdminCommandResponse>>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int ApplicationUserId { get; set; }
        public string ApplicationUserEmail { get; set; }
    }
}
