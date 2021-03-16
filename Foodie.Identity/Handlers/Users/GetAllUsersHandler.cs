using AutoMapper;
using Foodie.Identity.Models;
using Foodie.Identity.Queries.Users;
using Foodie.Identity.Repositories.Interfaces;
using Foodie.Identity.Responses.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Handlers.Users
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserResponse>>
    {
        private readonly IApplicationUsersRepository applicationUsersRepository;
        private readonly IMapper mapper;

        public GetAllUsersHandler(IApplicationUsersRepository applicationUsersRepository, IMapper mapper)
        {
            this.applicationUsersRepository = applicationUsersRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<UserResponse>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var applicationUsers = await applicationUsersRepository.GetApplicationUsers(ApplicationUserRoles.User);
            return mapper.Map<IEnumerable<UserResponse>>(applicationUsers);
        }

    }
}
