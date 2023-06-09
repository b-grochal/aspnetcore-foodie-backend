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
        public int Id { get; }
        public int CustomerId { get; }

        public GetCustomersOrderByIdQuery(int id, int customerId)
        {
            this.Id = id;
            this.CustomerId = customerId;
        }
    }
}
