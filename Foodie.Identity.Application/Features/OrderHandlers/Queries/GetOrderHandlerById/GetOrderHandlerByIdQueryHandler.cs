using AutoMapper;
using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Foodie.Identity.Application.Exceptions;
using MediatR;
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
            var orderHandler = await orderHandlersRepository.GetByIdAsync(request.Id);

            if (orderHandler == null)
                throw new ApplicationUserNotFoundException(request.Id);

            return mapper.Map<GetOrderHandlerByIdQueryResponse>(orderHandler);
        }
    }
}
