using AutoMapper;
using Foodie.Basket.Commands;
using Foodie.Basket.Models;
using Foodie.Basket.Repositories.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Basket.Handlers
{
    public class UpdateBasketHandler : IRequestHandler<UpdateBasketCommand>
    {
        private readonly IBasketRepository basketRepository;
        private readonly IMapper mapper;

        public UpdateBasketHandler(IBasketRepository basketRepository, IMapper mapper)
        {
            this.basketRepository = basketRepository;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateBasketCommand request, CancellationToken cancellationToken)
        {
            var updatedBasket = mapper.Map<CustomerBasket>(request);
            await basketRepository.UpdateBasket(updatedBasket);
            return new Unit();
        }
    }
}
