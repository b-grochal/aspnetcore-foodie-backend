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
            var admin = await adminsRepository.GetByIdAsync(request.Id);

            if (admin == null)
                throw new ApplicationUserNotFoundException(request.Id);

            var identityResult = await adminsRepository.DeleteAsync(admin);

            if(!identityResult.Succeeded)
                throw new ApplicationUserNotDeletedException(admin.Id);

            return new DeleteAdminCommandResponse
            {
                Id = request.Id
            };
        }
    }
}
