using AutoMapper;
using Foodie.Basket.Queries;
using Foodie.Basket.Repositories.Interfaces;
using Foodie.Basket.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Basket.Handlers
{
    public class GetBasketByIdHandler : IRequestHandler<GetBasketByIdQuery, CustomerBasketResponse>
    {
        private readonly IBasketRepository basketRepository;
        private readonly IMapper mapper;

        public GetBasketByIdHandler(IBasketRepository basketRepository, IMapper mapper)
        {
            this.basketRepository = basketRepository;
            this.mapper = mapper;
        }

        public async Task<CustomerBasketResponse> Handle(GetBasketByIdQuery request, CancellationToken cancellationToken)
        {
            var basket = await basketRepository.GetBasket(request.UserId);
            return mapper.Map<CustomerBasketResponse>(basket);
        }
    }
}
