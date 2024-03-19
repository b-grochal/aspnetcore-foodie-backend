using AutoMapper;
using Foodie.Common.Results;
using Foodie.Identity.Application.Contracts.Infrastructure.Database.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.OrderHandlers.Queries.GetOrderHandlers
{
    public class GetOrderHandlersQueryHandler : IRequestHandler<GetOrderHandlersQuery, Result<GetOrderHandlersQueryResponse>>
    {
        private readonly IOrderHandlersRepository orderHandlersRepository;
        private readonly IMapper mapper;

        public GetOrderHandlersQueryHandler(IOrderHandlersRepository orderHandlersRepository, IMapper mapper)
        {
            this.orderHandlersRepository = orderHandlersRepository;
            this.mapper = mapper;
        }

        public async Task<Result<GetOrderHandlersQueryResponse>> Handle(GetOrderHandlersQuery request, CancellationToken cancellationToken)
        {
            var result = await orderHandlersRepository.GetAllAsync(request.PageNumber, request.PageSize, request.Email);

            return new GetOrderHandlersQueryResponse
            {
                TotalCount = result.TotalCount,
                PageSize = request.PageSize,
                Page = result.Page,
                TotalPages = (int)Math.Ceiling(result.TotalCount / (double)request.PageSize),
                Items = mapper.Map<IEnumerable<OrderHandlerDto>>(result.Items),
                Email = request.Email
            };
        }
    }
}
