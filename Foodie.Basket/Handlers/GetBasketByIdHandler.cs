using Foodie.Basket.Queries;
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
        public Task<CustomerBasketResponse> Handle(GetBasketByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
