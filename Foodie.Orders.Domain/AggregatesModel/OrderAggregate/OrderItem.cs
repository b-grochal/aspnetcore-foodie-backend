using Foodie.Orders.Domain.Exceptions;
using Foodie.Orders.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Orders.Domain.AggregatesModel.OrderAggregate
{
    public class OrderItem : Entity
    {
        private string productName;
        private decimal unitPrice;
        private int units;

        public int ProductId { get; private set; }

        protected OrderItem() { }

        public OrderItem(int productId, string productName, decimal unitPrice, int units = 1)
        {
            if (units <= 0)
            {
                throw new OrderingDomainException("Invalid number of units");
            }

            this.ProductId = productId;

            this.productName = productName;
            this.unitPrice = unitPrice;
            this.units = units;
        }

        public int GetUnits() => units;

        public decimal GetUnitPrice() => unitPrice;

        public string GetOrderItemProductName() => productName;

        public void AddUnits(int units)
        {
            if (units < 0)
            {
                throw new OrderingDomainException("Invalid units");
            }

            this.units += units;
        }
    }
}
