using AutoMapper;
using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Foodie.Identity.Domain.Entities;
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
        private readonly IMapper mapper;

        public CreateAdminCommandHandler(IAdminsRepository adminsRepository, IMapper mapper)
        {
            this.adminsRepository = adminsRepository;
            this.mapper = mapper;
        }

        public async Task<CreateAdminCommandResponse> Handle(CreateAdminCommand request, CancellationToken cancellationToken)
        {
            var admin = mapper.Map<Admin>(request);
            admin.EmailConfirmed = true;
            admin.PhoneNumberConfirmed = true;

            await adminsRepository.CreateAsync(admin, request.Password);
            return mapper.Map<CreateAdminCommandResponse>(admin);
        }
    }
}
