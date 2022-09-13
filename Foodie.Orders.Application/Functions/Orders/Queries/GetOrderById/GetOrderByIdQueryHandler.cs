using AutoMapper;
using Foodie.Orders.Application.Contracts.Infrastructure.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Functions.Orders.Queries.GetOrderById
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, GetOrderByIdQueryResponse>
    {
        private readonly IOrderQueries _orderQueries;
        private readonly IMapper _mapper;

        public GetOrderByIdQueryHandler(IOrderQueries orderQueries, IMapper mapper)
        {
            _orderQueries = orderQueries;
            _mapper = mapper;
        }

        public async Task<GetOrderByIdQueryResponse> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderQueries.GetByIdAsync(request.OrderId);
            
            if(order == null)
                throw new NotImplementedException();

            return _mapper.Map<GetOrderByIdQueryResponse>(order);
        }
    }
}
