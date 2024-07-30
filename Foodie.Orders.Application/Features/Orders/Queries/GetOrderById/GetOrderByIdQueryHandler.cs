using AutoMapper;
using Foodie.Common.Results;
using Foodie.Orders.Application.Contracts.Infrastructure.Queries.Orders;
using Foodie.Orders.Application.Features.Orders.Errors;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Features.Orders.Queries.GetOrderById
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Result<GetOrderByIdQueryResponse>>
    {
        private readonly IOrdersReadServcie _orderQueries;
        private readonly IMapper _mapper;

        public GetOrderByIdQueryHandler(IOrdersReadServcie orderQueries, IMapper mapper)
        {
            _orderQueries = orderQueries;
            _mapper = mapper;
        }

        public async Task<Result<GetOrderByIdQueryResponse>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderQueries.GetByIdAsync(request.Id);

            if (order is null)
                return Result.Failure<GetOrderByIdQueryResponse>(OrderErrors.OrderNotFoundById(request.Id));

            return _mapper.Map<GetOrderByIdQueryResponse>(order);
        }
    }
}
