using Foodie.Basket.Commands;
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
        public Task<Unit> Handle(UpdateBasketCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
