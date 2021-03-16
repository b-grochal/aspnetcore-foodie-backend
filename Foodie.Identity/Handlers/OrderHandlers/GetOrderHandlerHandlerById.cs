using AutoMapper;
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
    public class GetOrderHandlerByIdHandler : IRequestHandler<GetOrderHandlerByIdQuery, OrderHandlerResponse>
    {
        private readonly IApplicationUsersRepository applicationUsersRepository;
        private readonly IMapper mapper;

        public GetOrderHandlerByIdHandler(IApplicationUsersRepository applicationUsersRepository, IMapper mapper)
        {
            this.applicationUsersRepository = applicationUsersRepository;
            this.mapper = mapper;
        }

        public async Task<OrderHandlerResponse> Handle(GetOrderHandlerByIdQuery request, CancellationToken cancellationToken)
        {
            var applicationUser = await applicationUsersRepository.GetApplicationUser(request.Id);
            return mapper.Map<OrderHandlerResponse>(applicationUser);
        }
    }
}
