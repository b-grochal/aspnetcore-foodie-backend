using Foodie.Shared.Responses;
using System.Collections.Generic;

namespace Foodie.Identity.Application.Functions.OrderHandlers.Queries.GetOrderHandlers
{
    public class GetOrderHandlersQueryResponse : PagedResponse
    {
        public IEnumerable<OrderHandlerDto> OrderHandlers { get; set; }
        public string Email { get; set; }
    }

    public class OrderHandlerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int LocationId { get; set; }
    }
}
