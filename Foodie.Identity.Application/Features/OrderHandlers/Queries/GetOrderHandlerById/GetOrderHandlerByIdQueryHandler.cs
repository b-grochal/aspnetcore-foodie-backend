using AutoMapper;
using Foodie.Common.Results;
using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Foodie.Identity.Application.Exceptions;
using Foodie.Identity.Application.Features.Common;
using Foodie.Identity.Domain.Common.ApplicationUser.Errors;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.OrderHandlers.Queries.GetOrderHandlerById
{
    public class GetOrderHandlerByIdQueryHandler : IRequestHandler<GetOrderHandlerByIdQuery, Result<GetOrderHandlerByIdQueryResponse>>
    {
        private readonly IOrderHandlersRepository orderHandlersRepository;
        private readonly IMapper mapper;

        public GetOrderHandlerByIdQueryHandler(IOrderHandlersRepository orderHandlersRepository, IMapper mapper)
        {
            this.orderHandlersRepository = orderHandlersRepository;
            this.mapper = mapper;
        }


        public async Task<Result<GetOrderHandlerByIdQueryResponse>> Handle(GetOrderHandlerByIdQuery request, CancellationToken cancellationToken)
        {
            var orderHandler = await orderHandlersRepository.GetByIdAsync(request.Id);

            if (orderHandler is null)
                return Result.Failure<GetOrderHandlerByIdQueryResponse>(ApplicationUserErrors.ApplicationUserNotFoundById(request.Id));

            return mapper.Map<GetOrderHandlerByIdQueryResponse>(orderHandler);
        }
    }
}
