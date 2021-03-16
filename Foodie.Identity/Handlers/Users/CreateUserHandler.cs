using AutoMapper;
using Foodie.Identity.Commands.Users;
using Foodie.Identity.Models;
using Foodie.Identity.Repositories.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Handlers.Users
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly IApplicationUsersRepository applicationUsersRepository;
        private readonly IMapper mapper;

        public CreateUserHandler(IApplicationUsersRepository applicationUsersRepository, IMapper mapper)
        {
            this.applicationUsersRepository = applicationUsersRepository;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var applicationUser = mapper.Map<ApplicationUser>(request);
            await applicationUsersRepository.CreateApplicationUser(applicationUser, ApplicationUserRoles.User);
            return new Unit();
        }
    }
}
