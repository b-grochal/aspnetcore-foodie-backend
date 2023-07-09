using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Contracts.Infrastructure.Queries.Orders
{
    public record OrderQueryDto
    {
        public int Id { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public int OrderStatusId { get; set; }
        public string OrderStatusName { get; set; }
        public int BuyerId { get; set; }
        public string BuyerEmail { get; set; }
        public int ContractorId { get; set; }
        public string ContractorName { get; set; }
    }

    public record OrderDetailsQueryDto
    {
        public int OrderId { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public string AddressStreet { get; set; }
        public string AddressCity { get; set; }
        public string AddressCountry { get; set; }
        public int OrderStatusId { get; set; }
        public string OrderStatusName { get; set; }
        public int BuyerId { get; set; }
        public string BuyerFirstName { get; set; }
        public string BuyerLastName { get; set; }
        public string BuyerPhoneNumber { get; set; }
        public string BuyerEmail { get; set; }
        public int ContractorId { get; set; }
        public string ContractorName { get; set; }
        public string ContractorAddress { get; set; }
        public string ContractorPhoneNumber { get; set; }
        public string ContractorEmail { get; set; }
        public string ContractorCity { get; set; }
        public string ContractorCountry { get; set; }
        public IList<OrderItemQueryDto> OrderItems { get; set; }
    }

    public record OrderItemQueryDto
    {
        public int OrderItemId { get; set; }
        public string Name { get; set; }
        public int Units { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
