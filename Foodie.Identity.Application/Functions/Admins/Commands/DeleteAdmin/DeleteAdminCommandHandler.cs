using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Foodie.Identity.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var adminToDelete = await adminsRepository.GetByIdAsync(request.AdminId);

            if (adminToDelete == null)
                throw new AdminNotFoundException(request.AdminId);

            await adminsRepository.DeleteAsync(adminToDelete);

            return new DeleteAdminCommandResponse
            {
                AdminId = request.AdminId
            };
        }
    }
}
