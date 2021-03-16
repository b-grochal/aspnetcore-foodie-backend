using Foodie.Identity.Commands.Users;
using Foodie.Identity.Repositories.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Handlers.Users
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IApplicationUsersRepository applicationUsersRepository;

        public DeleteUserHandler(IApplicationUsersRepository applicationUsersRepository)
        {
            this.applicationUsersRepository = applicationUsersRepository;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            await applicationUsersRepository.DeleteApplicationUser(request.Id);
            return new Unit();
        }
    }
}
