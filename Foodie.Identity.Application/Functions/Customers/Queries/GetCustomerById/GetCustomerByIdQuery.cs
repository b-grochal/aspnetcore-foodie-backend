using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.Customers.Queries.GetCustomerById
{
    public class GetCustomerByIdQuery : IRequest<GetCustomerByIdQueryResponse>
    {
        public string CustomerId { get; }

        public GetCustomerByIdQuery(string customerId)
        {
            this.CustomerId = customerId;
        }
    }
}
