using AutoMapper;
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
    public class EditAdminHandler : IRequestHandler<EditAdminCommand>
    {
        private readonly IApplicationUsersRepository applicationUsersRepository;
        private readonly IMapper mapper;

        public EditAdminHandler(IApplicationUsersRepository applicationUsersRepository, IMapper mapper)
        {
            this.applicationUsersRepository = applicationUsersRepository;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(EditAdminCommand request, CancellationToken cancellationToken)
        {
            var applicationUser = await applicationUsersRepository.GetApplicationUser(request.Id);
            var editedApplicationUser = mapper.Map(request, applicationUser);
            await applicationUsersRepository.EditApplicationUser(editedApplicationUser);
            return new Unit();
        }
    }
}
