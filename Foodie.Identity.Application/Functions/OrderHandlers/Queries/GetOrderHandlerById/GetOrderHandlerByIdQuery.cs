using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.OrderHandlers.Queries.GetOrderHandlerById
{
    public class GetOrderHandlerByIdQuery : IRequest<GetOrderHandlerByIdQueryResponse>
    {
        public string OrderHandlerId { get; }

        public GetOrderHandlerByIdQuery(string orderHandlerId)
        {
            this.OrderHandlerId = orderHandlerId;
        }
    }
}
