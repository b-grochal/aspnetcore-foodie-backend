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

namespace Foodie.Identity.Application.Functions.OrderHandlers.Queries.GetOrderHandlerById
{
    public class GetOrderHandlerByIdQueryHandler : IRequestHandler<GetOrderHandlerByIdQuery, GetOrderHandlerByIdQueryResponse>
    {
        private readonly IOrderHandlersRepository orderHandlersRepository;
        private readonly IMapper mapper;

        public GetOrderHandlerByIdQueryHandler(IOrderHandlersRepository orderHandlersRepository, IMapper mapper)
        {
            this.orderHandlersRepository = orderHandlersRepository;
            this.mapper = mapper;
        }


        public async Task<GetOrderHandlerByIdQueryResponse> Handle(GetOrderHandlerByIdQuery request, CancellationToken cancellationToken)
        {
            var orderHandler = await orderHandlersRepository.GetByIdAsync(request.OrderHandlerId);

            if (orderHandler == null)
                throw new ApplicationUserNotFoundException(request.OrderHandlerId);

            return mapper.Map<GetOrderHandlerByIdQueryResponse>(orderHandler);
        }
    }
}
