using AutoMapper;
using Foodie.Identity.Models;
using Foodie.Identity.Queries.OrderHandlers;
using Foodie.Identity.Repositories.Interfaces;
using Foodie.Identity.Responses.OrderHandlers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Handlers.OrderHandlers
{
    public class GetAllOrderHandlersHandler : IRequestHandler<GetAllOrderHandlersQuery, IEnumerable<OrderHandlerResponse>>
    {
        private readonly IApplicationUsersRepository applicationUsersRepository;
        private readonly IMapper mapper;

        public GetAllOrderHandlersHandler(IApplicationUsersRepository applicationUsersRepository, IMapper mapper)
        {
            this.applicationUsersRepository = applicationUsersRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<OrderHandlerResponse>> Handle(GetAllOrderHandlersQuery request, CancellationToken cancellationToken)
        {
            var applicationUsers = await applicationUsersRepository.GetApplicationUsers(ApplicationUserRoles.OrderHandler);
            return mapper.Map<IEnumerable<OrderHandlerResponse>>(applicationUsers);
        }
    }
}
