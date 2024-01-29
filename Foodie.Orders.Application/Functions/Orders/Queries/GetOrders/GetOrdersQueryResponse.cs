using Foodie.Common.Application.Responses;
using System;
using System.Collections.Generic;

namespace Foodie.Orders.Application.Functions.Orders.Queries.GetOrders
{
    public class GetOrdersQueryResponse : PagedResponse<OrderDto>
    {
        public IEnumerable<OrderDto> Orders { get; set; }
        public string BuyerEmail { get; set; }
        public string OrderStatusName { get; set; }
        public string ContractorName { get; set; }
        public int? LocationId { get; set; }
    }

    public class OrderDto
    {
        public int Id { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public int OrderStatusId { get; set; }
        public string OrderStatusName { get; set; }
        public int BuyerId { get; set; }
        public string BuyerEmail { get; set; }
        public int ContractorId { get; set; }
        public string ContactorName { get; set; }
    }
}
