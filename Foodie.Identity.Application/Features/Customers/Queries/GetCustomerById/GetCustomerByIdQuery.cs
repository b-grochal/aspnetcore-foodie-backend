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
        public int Id { get; }

        public GetCustomerByIdQuery(int id)
        {
            this.Id = id;
        }
    }
}
