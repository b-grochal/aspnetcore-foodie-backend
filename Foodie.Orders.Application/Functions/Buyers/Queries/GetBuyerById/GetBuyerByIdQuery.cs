using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Functions.Buyers.Queries.GetBuyerById
{
    public class GetBuyerByIdQuery : IRequest<GetBuyerByIdQueryResponse>
    {
        public int BuyerId { get; }

        public GetBuyerByIdQuery(int orderId)
        {
            this.BuyerId = orderId;
        }
    }
}
