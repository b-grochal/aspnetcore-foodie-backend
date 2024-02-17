using Foodie.Common.Application.Queries;
using MediatR;

namespace Foodie.Identity.Application.Functions.Customers.Queries.GetCustomers
{
    public class GetCustomersQuery : PagedQuery, IRequest<GetCustomersQueryResponse>
    {
        public string Email { get; set; }
    }
}
