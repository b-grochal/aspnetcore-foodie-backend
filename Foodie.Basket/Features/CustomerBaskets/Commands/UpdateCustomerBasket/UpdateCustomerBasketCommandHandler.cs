using AutoMapper;
using Foodie.Basket.Model;
using Foodie.Basket.Repositories.Interfaces;
using Foodie.Common.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Basket.API.Functions.CustomerBaskets.Commands.UpdateCustomerBasket
{
    public class UpdateCustomerBasketCommandHandler : IRequestHandler<UpdateCustomerBasketCommand, Result<UpdateCustomerBasketCommandResponse>>
    {
        private readonly ICustomerBasketsRepository customerBasketsRepository;
        private readonly IMapper mapper;

        public UpdateCustomerBasketCommandHandler(ICustomerBasketsRepository customerBasketsRepository, IMapper mapper)
        {
            this.customerBasketsRepository = customerBasketsRepository;
            this.mapper = mapper;
        }

        public async Task<Result<UpdateCustomerBasketCommandResponse>> Handle(UpdateCustomerBasketCommand request, CancellationToken cancellationToken)
        {
            var result = await customerBasketsRepository.UpdateBasket(request.ApplicationUserId, mapper.Map<CustomerBasket>(request));
            return mapper.Map<UpdateCustomerBasketCommandResponse>(result);
        }
    }
}
