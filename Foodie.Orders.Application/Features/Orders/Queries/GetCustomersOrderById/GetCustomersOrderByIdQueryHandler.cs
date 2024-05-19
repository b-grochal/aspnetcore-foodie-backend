using AutoMapper;
using Foodie.Common.Results;
using Foodie.Orders.Application.Contracts.Infrastructure.Queries.Orders;
using Foodie.Orders.Application.Features.Orders.Errors;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Features.Orders.Queries.GetCustomersOrderById
{
    public class GetCustomersOrderByIdQueryHandler : IRequestHandler<GetCustomersOrderByIdQuery, Result<GetCustomersOrderByIdQueryResponse>>
    {
        private readonly IOrdersQueries _orderQueries;
        private readonly IMapper _mapper;

        public GetCustomersOrderByIdQueryHandler(IOrdersQueries orderQueries, IMapper mapper)
        {
            _orderQueries = orderQueries;
            _mapper = mapper;
        }

        public async Task<Result<GetCustomersOrderByIdQueryResponse>> Handle(GetCustomersOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var customersOrder = await _orderQueries.GetByIdAsync(request.Id, request.ApplicationUserId);

            if (customersOrder is null)
                return Result.Failure<GetCustomersOrderByIdQueryResponse>(OrderErrors.CustomersOrderNotFoundById(request.Id, request.ApplicationUserId));

            return _mapper.Map<GetCustomersOrderByIdQueryResponse>(customersOrder);
        }
    }
}
