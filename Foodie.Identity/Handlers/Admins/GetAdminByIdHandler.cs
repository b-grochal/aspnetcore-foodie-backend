using AutoMapper;
using Foodie.Identity.Queries.Admins;
using Foodie.Identity.Repositories.Interfaces;
using Foodie.Identity.Responses.Admins;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Handlers.Admins
{
    public class GetAdminByIdHandler : IRequestHandler<GetAdminByIdQuery, AdminResponse>
    {
        private readonly IApplicationUsersRepository applicationUsersRepository;
        private readonly IMapper mapper;

        public GetAdminByIdHandler(IApplicationUsersRepository applciationUsersRepository, IMapper mapper)
        {
            this.applicationUsersRepository = applciationUsersRepository;
            this.mapper = mapper;
        }

        public async Task<AdminResponse> Handle(GetAdminByIdQuery request, CancellationToken cancellationToken)
        {
            var applicationUser = await applicationUsersRepository.GetApplicationUser(request.Id);
            return mapper.Map<AdminResponse>(applicationUser);
        }
    }
}
