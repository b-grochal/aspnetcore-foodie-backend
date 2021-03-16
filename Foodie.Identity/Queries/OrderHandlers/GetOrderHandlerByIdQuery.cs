using Foodie.Identity.Responses.OrderHandlers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.Identity.Queries.OrderHandlers
{
    public class GetOrderHandlerByIdQuery : IRequest<OrderHandlerResponse>
    {
        public string Id { get; set; }

        public GetOrderHandlerByIdQuery(string id)
        {
            this.Id = id;
        }
    }
}
