using AutoMapper;
using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Foodie.Identity.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.Admins.Commands.UpdateAdmin
{
    public class UpdateAdminCommandHandler : IRequestHandler<UpdateAdminCommand, UpdateAdminCommandResponse>
    {
        private readonly IAdminsRepository adminsRepository;
        private readonly IMapper mapper;

        public UpdateAdminCommandHandler(IAdminsRepository adminsRepository, IMapper mapper)
        {
            this.adminsRepository = adminsRepository;
            this.mapper = mapper;
        }

        public async Task<UpdateAdminCommandResponse> Handle(UpdateAdminCommand request, CancellationToken cancellationToken)
        {
            var admin = await adminsRepository.GetByIdAsync(request.AdminId);

            if (admin == null)
                throw new AdminNotFoundException(request.AdminId);

            var editedAdmin = mapper.Map(request, admin);
            await adminsRepository.UpdateAsync(editedAdmin);
            return mapper.Map<UpdateAdminCommandResponse>(editedAdmin);
        }
    }
}
