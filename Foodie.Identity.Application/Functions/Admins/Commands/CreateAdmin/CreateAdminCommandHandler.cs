using AutoMapper;
using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Foodie.Identity.Application.Contracts.Infrastructure.Services;
using Foodie.Identity.Domain.Entities;
using Foodie.Identity.Domain.Exceptions;
using Foodie.Shared.Enums;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.Admins.Commands.CreateAdmin
{
    public class CreateAdminCommandHandler : IRequestHandler<CreateAdminCommand, CreateAdminCommandResponse>
    {
        private readonly IAdminsRepository adminsRepository;
        private readonly IApplicationUsersRepository applicationUsersRepository;
        private readonly IPasswordService passwordService;
        private readonly IMapper mapper;

        public CreateAdminCommandHandler(IAdminsRepository adminsRepository, IApplicationUsersRepository applicationUsersRepository, IPasswordService passwordService, IMapper mapper)
        {
            this.adminsRepository = adminsRepository;
            this.applicationUsersRepository = applicationUsersRepository;
            this.passwordService = passwordService;
            this.mapper = mapper;
        }

        public async Task<CreateAdminCommandResponse> Handle(CreateAdminCommand request, CancellationToken cancellationToken)
        {
            if ((await applicationUsersRepository.GetByEmailAsync(request.Email)) is not null)
                throw new ApplicationUserAlreadyExistsException(request.Email);

            var admin = mapper.Map<Admin>(request);

            admin.PasswordHash = passwordService.HashPassword(request.Password);
            admin.Role = ApplicationUserRole.Admin;

            await adminsRepository.CreateAsync(admin);

            return mapper.Map<CreateAdminCommandResponse>(admin);
        }
    }
}
