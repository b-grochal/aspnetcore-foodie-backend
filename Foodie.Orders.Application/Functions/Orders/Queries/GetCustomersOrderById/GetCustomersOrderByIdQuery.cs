using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Functions.Orders.Queries.GetCustomersOrderById
{
    public class GetCustomersOrderByIdQuery : IRequest<GetCustomersOrderByIdQueryResponse>
    {
        public int OrderId { get; }
        public string UserId { get; }

        public GetCustomersOrderByIdQuery(int orderId, string userId)
        {
            this.OrderId = orderId;
            this.UserId = userId;
        }
    }
}
