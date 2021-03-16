using AutoMapper;
using Foodie.Identity.Models;
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
    public class GetAllAdminsHandler : IRequestHandler<GetAllAdminsQuery, IEnumerable<AdminResponse>>
    {
        private readonly IApplicationUsersRepository applicationUsersRepository;
        private readonly IMapper mapper;

        public GetAllAdminsHandler(IApplicationUsersRepository applicationUsersRepository, IMapper mapper)
        {
            this.applicationUsersRepository = applicationUsersRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<AdminResponse>> Handle(GetAllAdminsQuery request, CancellationToken cancellationToken)
        {
            var applicationUsers = await applicationUsersRepository.GetApplicationUsers(ApplicationUserRoles.Admin);
            return mapper.Map<IEnumerable<AdminResponse>>(applicationUsers);
        }
    }
}
