using AutoMapper;
using Foodie.Basket.API.Errors;
using Foodie.Basket.Repositories.Interfaces;
using Foodie.Common.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Basket.API.Functions.CustomerBaskets.Queries.GetCustomerBasketByCustomerId
{
    public class GetCustomerBasketByCustomerIdQueryHandler : IRequestHandler<GetCustomerBasketByCustomerIdQuery, Result<GetCustomerBasketByCustomerIdQueryResponse>>
    {
        private readonly ICustomerBasketsRepository _customerBasketsRepository;
        private readonly IMapper _mapper;

        public GetCustomerBasketByCustomerIdQueryHandler(ICustomerBasketsRepository customerBasketsRepository, IMapper mapper)
        {
            _customerBasketsRepository = customerBasketsRepository;
            _mapper = mapper;
        }

        public async Task<Result<GetCustomerBasketByCustomerIdQueryResponse>> Handle(GetCustomerBasketByCustomerIdQuery request, CancellationToken cancellationToken)
        {
            var customerBasket = await _customerBasketsRepository.GetByCustomerId(request.ApplicationUserId);

            if (customerBasket == null)
                return Result.Failure<GetCustomerBasketByCustomerIdQueryResponse>(BasketsErrors.BasketNotFoundByApplicationUserId(request.ApplicationUserId));

            return _mapper.Map<GetCustomerBasketByCustomerIdQueryResponse>(customerBasket);
        }
    }
}
