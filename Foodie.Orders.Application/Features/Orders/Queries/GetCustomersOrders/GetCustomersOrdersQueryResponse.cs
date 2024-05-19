using Foodie.Common.Application.Responses;
using System;

namespace Foodie.Orders.Application.Features.Orders.Queries.GetCustomersOrders
{
    public class GetCustomersOrdersQueryResponse : PagedResponse<CustomersOrderDto>
    {
        public int? OrderStatusId { get; set; }
        public string ContractorName { get; set; }
    }

    public class CustomersOrderDto
    {
        public int Id { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public int OrderStatusId { get; set; }
        public string OrderStatusName { get; set; }
        public int ContractorId { get; set; }
        public string ContractorName { get; set; }
    }
}
