using Foodie.Common.Results;
using MediatR;

namespace Foodie.Identity.Application.Functions.Admins.Commands.DeleteAdmin
{
    public class DeleteAdminCommand : IRequest<Result<DeleteAdminCommandResponse>>
    {
        public int Id { get; set; }

        public DeleteAdminCommand(int id)
        {
            this.Id = id;
        }
    }
}
