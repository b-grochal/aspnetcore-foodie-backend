using Foodie.Common.Application.Requests.Commands.Interfaces;
using Foodie.Common.Results;
using MediatR;

namespace Foodie.Identity.Application.Functions.Admins.Commands.DeleteAdmin
{
    public class DeleteAdminCommand : IRequest<Result<DeleteAdminCommandResponse>>, IAuditableCommand
    {
        public int Id { get; set; }
        public int ApplicationUserId { get; set; }

        public string ApplicationUserEmail { get; set; }

        public DeleteAdminCommand(int id)
        {
            this.Id = id;
        }
    }
}
