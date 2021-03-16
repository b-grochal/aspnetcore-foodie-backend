using AutoMapper;
using Foodie.Identity.Commands.Admins;
using Foodie.Identity.Models;
using Foodie.Identity.Repositories.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Handlers.Admins
{
    public class CreateAdminHandler : IRequestHandler<CreateAdminCommand>
    {
        private readonly IApplicationUsersRepository applicationUsersRepository;
        private readonly IMapper mapper;

        public CreateAdminHandler(IApplicationUsersRepository applicationUsersRepository, IMapper mapper)
        {
            this.applicationUsersRepository = applicationUsersRepository;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(CreateAdminCommand request, CancellationToken cancellationToken)
        {
            var applicationUser = mapper.Map<ApplicationUser>(request);
            await applicationUsersRepository.CreateApplicationUser(applicationUser, ApplicationUserRoles.Admin);
            return new Unit();
        }
    }
}
