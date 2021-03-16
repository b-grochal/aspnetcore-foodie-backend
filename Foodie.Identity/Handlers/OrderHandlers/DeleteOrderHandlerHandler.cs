using Foodie.Identity.Commands.OrderHandlers;
using Foodie.Identity.Repositories.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Handlers.OrderHandlers
{
    public class DeleteOrderHandlerHandler : IRequestHandler<DeleteOrderHandlerCommand>
    {
        private readonly IApplicationUsersRepository applicationUsersRepository;

        public DeleteOrderHandlerHandler(IApplicationUsersRepository applicationUsersRepository)
        {
            this.applicationUsersRepository = applicationUsersRepository;
        }

        public async Task<Unit> Handle(DeleteOrderHandlerCommand request, CancellationToken cancellationToken)
        {
            await applicationUsersRepository.DeleteApplicationUser(request.Id);
            return new Unit();
        }
    }
}
