using AutoMapper;
using Foodie.Common.Results;
using Foodie.Orders.Application.Contracts.Infrastructure.Queries.Orders;
using Foodie.Orders.Application.Features.Orders.Errors;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Features.Orders.Queries.GetCustomersOrderById
{
    public class GetMyOrderByIdQueryHandler : IRequestHandler<GetMyOrderByIdQuery, Result<GetMyOrderByIdQueryResponse>>
    {
        private readonly IOrdersReadServcie _orderQueries;
        private readonly IMapper _mapper;

        public GetMyOrderByIdQueryHandler(IOrdersReadServcie orderQueries, IMapper mapper)
        {
            _orderQueries = orderQueries;
            _mapper = mapper;
        }

        public async Task<Result<GetMyOrderByIdQueryResponse>> Handle(GetMyOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var customersOrder = await _orderQueries.GetMyOrderByIdAsync(request.Id, request.ApplicationUserId);

            if (customersOrder is null)
                return Result.Failure<GetMyOrderByIdQueryResponse>(OrderErrors.CustomersOrderNotFoundById(request.Id, request.ApplicationUserId));

            return _mapper.Map<GetMyOrderByIdQueryResponse>(customersOrder);
        }
    }
}
