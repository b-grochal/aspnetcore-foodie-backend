using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Functions.Orders.Queries.GetCustomersOrderById
{
    public class GetCustomersOrderByIdQueryResponse
    {
        public int OrderId { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public string AddressStreet { get; set; }
        public string AddressCity { get; set; }
        public string AddressCountry { get; set; }
        public int OrderStatusId { get; set; }
        public string OrderStatusName { get; set; }
        public int ContractorId { get; set; }
        public string ContractorName { get; set; }
        public string ContractorAddress { get; set; }
        public string ContractorPhoneNumber { get; set; }
        public string ContractorEmail { get; set; }
        public string ContractorCity { get; set; }
        public string ContractorCountry { get; set; }
        public IList<CustomersOrderItemDto> CustomersOrderItems { get; set; }
    }

    public class CustomersOrderItemDto
    {
        public int OrderItemId { get; set; }
        public string Name { get; set; }
        public int Units { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
