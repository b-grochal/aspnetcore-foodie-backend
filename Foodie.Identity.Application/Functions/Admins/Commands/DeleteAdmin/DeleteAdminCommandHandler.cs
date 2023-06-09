using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Foodie.Identity.Domain.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.Admins.Commands.DeleteAdmin
{
    public class DeleteAdminCommandHandler : IRequestHandler<DeleteAdminCommand, DeleteAdminCommandResponse>
    {
        private readonly IAdminsRepository adminsRepository;

        public DeleteAdminCommandHandler(IAdminsRepository adminsRepository)
        {
            this.adminsRepository = adminsRepository;
        }

        public async Task<DeleteAdminCommandResponse> Handle(DeleteAdminCommand request, CancellationToken cancellationToken)
        {
            var admin = await adminsRepository.GetByIdAsync(request.Id);

            if (admin == null)
                throw new ApplicationUserNotFoundException(request.Id);

            await adminsRepository.DeleteAsync(admin);

            return new DeleteAdminCommandResponse
            {
                Id = request.Id
            };
        }
    }
}
