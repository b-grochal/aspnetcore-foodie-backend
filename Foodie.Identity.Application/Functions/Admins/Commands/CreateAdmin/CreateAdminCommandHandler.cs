using AutoMapper;
using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Foodie.Identity.Domain.Entities;
using Foodie.Identity.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.Admins.Commands.CreateAdmin
{
    public class CreateAdminCommandHandler : IRequestHandler<CreateAdminCommand, CreateAdminCommandResponse>
    {
        private readonly IAdminsRepository adminsRepository;
        private readonly IApplicationUserRolesRepository applicationUserRolesRepository;
        private readonly IMapper mapper;

        public CreateAdminCommandHandler(IAdminsRepository adminsRepository, IApplicationUserRolesRepository applicationUserRolesRepository, IMapper mapper)
        {
            this.adminsRepository = adminsRepository;
            this.applicationUserRolesRepository = applicationUserRolesRepository;
            this.mapper = mapper;
        }

        public async Task<CreateAdminCommandResponse> Handle(CreateAdminCommand request, CancellationToken cancellationToken)
        {
            var admin = mapper.Map<Admin>(request);

            admin.EmailConfirmed = true;
            admin.PhoneNumberConfirmed = true;

            var identityResult = await adminsRepository.CreateAsync(admin, request.Password);

            if (!identityResult.Succeeded)
                throw new ApplicationUserNotCreatedException();

            identityResult = await applicationUserRolesRepository.CreateApplicationUserRole(admin, ApplicationUserRoles.Admin);

            if (!identityResult.Succeeded)
                throw new ApplicationUserRoleNotCreatedException(admin.Id, ApplicationUserRoles.Admin);

            return mapper.Map<CreateAdminCommandResponse>(admin);
        }
    }
}
