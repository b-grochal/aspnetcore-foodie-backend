using Foodie.Common.Application.Queries;
using Foodie.Common.Results;
using MediatR;

namespace Foodie.Identity.Application.Functions.Customers.Queries.GetCustomers
{
    public class GetCustomersQuery : PagedQuery, IRequest<Result<GetCustomersQueryResponse>>
    {
        public string Email { get; set; }
    }
}
