using AutoMapper;
using Foodie.Orders.Application.Contracts.Infrastructure.Queries.Orders;
using Foodie.Orders.Domain.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Functions.Orders.Queries.GetOrderById
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, GetOrderByIdQueryResponse>
    {
        private readonly IOrdersQueries _orderQueries;
        private readonly IMapper _mapper;

        public GetOrderByIdQueryHandler(IOrdersQueries orderQueries, IMapper mapper)
        {
            _orderQueries = orderQueries;
            _mapper = mapper;
        }

        public async Task<GetOrderByIdQueryResponse> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderQueries.GetByIdAsync(request.Id);

            if (order == null)
                throw new OrderNotFoundException(request.Id);

            return _mapper.Map<GetOrderByIdQueryResponse>(order);
        }
    }
}
