using AutoMapper;
using Foodie.Orders.Application.Contracts.Infrastructure.Queries.Orders;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Functions.Orders.Queries.GetOrders
{
    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, GetOrdersQueryResponse>
    {
        private readonly IOrdersQueries _orderQueries;
        private readonly IMapper _mapper;

        public GetOrdersQueryHandler(IOrdersQueries orderQueries, IMapper mapper)
        {
            _orderQueries = orderQueries;
            _mapper = mapper;
        }

        public async Task<GetOrdersQueryResponse> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderQueries.GetAllAsync(request.PageNumber, request.PageSize, request.BuyerEmail, request.OrderStatusName, request.ContractorName, request.LocationId);

            return new GetOrdersQueryResponse
            {
                TotalCount = orders.TotalCount,
                PageSize = orders.PageSize,
                Page = orders.Page,
                TotalPages = (int)Math.Ceiling(orders.TotalCount / (double)orders.PageSize),
                Orders = _mapper.Map<IEnumerable<OrderDto>>(orders),
                BuyerEmail = request.BuyerEmail,
                OrderStatusName = request.OrderStatusName,
                ContractorName = request.ContractorName
            };
        }
    }
}
