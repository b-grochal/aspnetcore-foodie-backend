using Foodie.Identity.Commands.Admins;
using Foodie.Identity.Repositories.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Handlers.Admins
{
    public class DeleteAdminHandler : IRequestHandler<DeleteAdminCommand>
    {
        private readonly IApplicationUsersRepository applicationUsersRepository;

        public DeleteAdminHandler(IApplicationUsersRepository applicationUsersRepository)
        {
            this.applicationUsersRepository = applicationUsersRepository;
        }

        public async Task<Unit> Handle(DeleteAdminCommand request, CancellationToken cancellationToken)
        {
            await applicationUsersRepository.DeleteApplicationUser(request.Id);
            return new Unit();
        }
    }
}
