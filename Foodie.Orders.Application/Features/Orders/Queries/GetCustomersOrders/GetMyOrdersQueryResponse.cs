using Foodie.Common.Application.Responses;
using System;

namespace Foodie.Orders.Application.Features.Orders.Queries.GetCustomersOrders
{
    public class GetMyOrdersQueryResponse : PagedResponse<MyOrderDto>
    {
        public string OrderStatus { get; set; }
        public string ContractorName { get; set; }
    }

    public class MyOrderDto
    {
        public int Id { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public string OrderStatus { get; set; }
        public int ContractorId { get; set; }
        public string ContractorName { get; set; }
    }
}
