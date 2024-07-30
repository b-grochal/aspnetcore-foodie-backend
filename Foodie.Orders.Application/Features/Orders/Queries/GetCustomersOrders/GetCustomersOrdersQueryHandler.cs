using AutoMapper;
using Foodie.Common.Results;
using Foodie.Orders.Application.Contracts.Infrastructure.Queries.Orders;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Features.Orders.Queries.GetCustomersOrders
{
    public class GetCustomersOrdersQueryHandler : IRequestHandler<GetCustomersOrdersQuery, Result<GetCustomersOrdersQueryResponse>>
    {
        private readonly IOrdersReadServcie _orderQueries;
        private readonly IMapper _mapper;

        public GetCustomersOrdersQueryHandler(IOrdersReadServcie orderQueries, IMapper mapper)
        {
            _orderQueries = orderQueries;
            _mapper = mapper;
        }

        public async Task<Result<GetCustomersOrdersQueryResponse>> Handle(GetCustomersOrdersQuery request, CancellationToken cancellationToken)
        {
            var customersOrders = await _orderQueries.GetAllAsync(request.PageNumber, request.PageSize, request.ApplicationUserId, request.OrderStatusId, request.ContractorName);

            return new GetCustomersOrdersQueryResponse
            {
                TotalCount = customersOrders.TotalCount,
                PageSize = customersOrders.PageSize,
                Page = customersOrders.Page,
                TotalPages = (int)Math.Ceiling(customersOrders.TotalCount / (double)customersOrders.PageSize),
                Items = _mapper.Map<IEnumerable<CustomersOrderDto>>(customersOrders.Items),
                OrderStatusId = request.OrderStatusId,
                ContractorName = request.ContractorName
            };
        }
    }
}
