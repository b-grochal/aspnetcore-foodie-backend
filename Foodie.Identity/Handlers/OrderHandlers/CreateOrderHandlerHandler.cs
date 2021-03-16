using AutoMapper;
using Foodie.Identity.Commands.OrderHandlers;
using Foodie.Identity.Models;
using Foodie.Identity.Repositories.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Handlers.OrderHandlers
{
    public class CreateOrderHandlerHandler : IRequestHandler<CreateOrderHandlerCommand>
    {
        private readonly IApplicationUsersRepository applicationUsersRepository;
        private readonly IMapper mapper;

        public CreateOrderHandlerHandler(IApplicationUsersRepository applicationUsersRepository, IMapper mapper)
        {
            this.applicationUsersRepository = applicationUsersRepository;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(CreateOrderHandlerCommand request, CancellationToken cancellationToken)
        {
            var applicationUser = mapper.Map<ApplicationUser>(request);
            await applicationUsersRepository.CreateApplicationUser(applicationUser, ApplicationUserRoles.OrderHandler);
            return new Unit();
        }
    }
}
