using Foodie.Basket.Commands;
using Foodie.Basket.Repositories.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Basket.Handlers
{
    public class DeleteBasketHandler : IRequestHandler<DeleteBasketCommand>
    {
        private readonly IBasketRepository basketRepository;

        public DeleteBasketHandler(IBasketRepository basketRepository)
        {
            this.basketRepository = basketRepository;
        }

        public async Task<Unit> Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
        {
            await basketRepository.DeleteBasket(request.UserId);
            return new Unit();
        }
    }
}
