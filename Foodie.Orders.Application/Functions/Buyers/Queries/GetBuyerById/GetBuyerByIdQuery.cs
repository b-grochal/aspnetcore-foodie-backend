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
        public int Id { get; }

        public GetBuyerByIdQuery(int id)
        {
            this.Id = id;
        }
    }
}
