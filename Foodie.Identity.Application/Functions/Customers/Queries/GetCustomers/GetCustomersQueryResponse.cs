using Foodie.Shared.Responses;
using System.Collections.Generic;

namespace Foodie.Identity.Application.Functions.Customers.Queries.GetCustomers
{
    public class GetCustomersQueryResponse : PagedResponse
    {
        public IEnumerable<CustomerDto> Customers { get; set; }
        public string Email { get; set; }
    }

    public class CustomerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
