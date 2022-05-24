using AutoMapper;
using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.OrderHandlers.Queries.GetOrderHandlers
{
    public class GetOrderHandlersQueryHandler : IRequestHandler<GetOrderHandlersQuery, GetOrderHandlersQueryResponse>
    {
        private readonly IOrderHandlersRepository orderHandlersRepository;
        private readonly IMapper mapper;

        public GetOrderHandlersQueryHandler(IOrderHandlersRepository orderHandlersRepository, IMapper mapper)
        {
            this.orderHandlersRepository = orderHandlersRepository;
            this.mapper = mapper;
        }

        public async Task<GetOrderHandlersQueryResponse> Handle(GetOrderHandlersQuery request, CancellationToken cancellationToken)
        {
            var orderHandlers = await orderHandlersRepository.GetAllAsync(request.PageNumber, request.PageSize, request.Email);

            return new GetOrderHandlersQueryResponse
            {
                TotalCount = orderHandlers.TotalCount,
                PageSize = orderHandlers.PageSize,
                CurrentPage = orderHandlers.CurrentPage,
                TotalPages = (int)Math.Ceiling(orderHandlers.TotalCount / (double)orderHandlers.PageSize),
                OrderHandlers = mapper.Map<IEnumerable<OrderHandlerDto>>(orderHandlers),
                Email = request.Email
            };
        }
    }
}
