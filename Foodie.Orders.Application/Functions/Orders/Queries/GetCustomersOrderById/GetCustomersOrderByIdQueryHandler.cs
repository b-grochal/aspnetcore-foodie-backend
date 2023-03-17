using AutoMapper;
using Foodie.Orders.Application.Contracts.Infrastructure.Queries.Orders;
using Foodie.Orders.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Functions.Orders.Queries.GetCustomersOrderById
{
    public class GetCustomersOrderByIdQueryHandler : IRequestHandler<GetCustomersOrderByIdQuery, GetCustomersOrderByIdQueryResponse>
    {
        private readonly IOrdersQueries _orderQueries;
        private readonly IMapper _mapper;

        public GetCustomersOrderByIdQueryHandler(IOrdersQueries orderQueries, IMapper mapper)
        {
            _orderQueries = orderQueries;
            _mapper = mapper;
        }

        public async Task<GetCustomersOrderByIdQueryResponse> Handle(GetCustomersOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var customersOrder = await _orderQueries.GetByIdAsync(request.OrderId, request.CustomerId);

            if (customersOrder == null)
                throw new OrderNotFoundException(request.OrderId);

            return _mapper.Map<GetCustomersOrderByIdQueryResponse>(customersOrder);
        }
    }
}
