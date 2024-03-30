using AutoMapper;
using Foodie.Basket.API.Exceptions;
using Foodie.Basket.Repositories.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Basket.API.Functions.CustomerBaskets.Queries.GetCustomerBasketByCustomerId
{
    public class GetCustomerBasketByCustomerIdQueryHandler : IRequestHandler<GetCustomerBasketByCustomerIdQuery, GetCustomerBasketByCustomerIdQueryResponse>
    {
        private readonly ICustomerBasketsRepository customerBasketsRepository;
        private readonly IMapper mapper;

        public GetCustomerBasketByCustomerIdQueryHandler(ICustomerBasketsRepository customerBasketsRepository, IMapper mapper)
        {
            this.customerBasketsRepository = customerBasketsRepository;
            this.mapper = mapper;
        }

        public async Task<GetCustomerBasketByCustomerIdQueryResponse> Handle(GetCustomerBasketByCustomerIdQuery request, CancellationToken cancellationToken)
        {
            var customerBasket = await customerBasketsRepository.GetByCustomerId(request.ApplicationUserId);

            if (customerBasket == null)
                throw new CustomerBasketNotFoundException(request.ApplicationUserId);

            return mapper.Map<GetCustomerBasketByCustomerIdQueryResponse>(customerBasket);
        }
    }
}
