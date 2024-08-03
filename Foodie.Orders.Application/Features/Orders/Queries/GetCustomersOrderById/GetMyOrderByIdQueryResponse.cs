using System;
using System.Collections.Generic;

namespace Foodie.Orders.Application.Features.Orders.Queries.GetCustomersOrderById
{
    public class GetMyOrderByIdQueryResponse
    {
        public int Id { get; set; }
        public string AddressStreet { get; set; }
        public string AddressCity { get; set; }
        public string AddressCountry { get; set; }
        public string OrderStatus { get; set; }
        public int ContractorId { get; set; }
        public string ContractorName { get; set; }
        public string ContractorAddress { get; set; }
        public string ContractorPhoneNumber { get; set; }
        public string ContractorEmail { get; set; }
        public string ContractorCity { get; set; }
        public string ContractorCountry { get; set; }
        public IList<MyOrderItemDto> Items { get; set; }
    }

    public class MyOrderItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
