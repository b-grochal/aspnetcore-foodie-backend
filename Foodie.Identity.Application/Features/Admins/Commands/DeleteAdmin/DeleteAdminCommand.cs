using MediatR;

namespace Foodie.Identity.Application.Functions.Admins.Commands.DeleteAdmin
{
    public class DeleteAdminCommand : IRequest<DeleteAdminCommandResponse>
    {
        public int Id { get; set; }

        public DeleteAdminCommand(int id)
        {
            this.Id = id;
        }
    }
}
