using Foodie.Basket.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Basket.Queries
{
    public class GetBasketByIdQuery : IRequest<CustomerBasketResponse>
    {
        public string UserId{ get; }

        public GetBasketByIdQuery(string userId)
        {
            this.UserId = userId;
        }
    }
}
