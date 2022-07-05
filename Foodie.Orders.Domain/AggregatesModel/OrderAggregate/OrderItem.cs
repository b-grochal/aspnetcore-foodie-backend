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
        private string _mealName;
        private decimal _unitPrice;
        private int _quantity;

        public int ProductId { get; private set; }

        protected OrderItem() { }

        public OrderItem(int productId, string productName, decimal unitPrice, int quantity = 1)
        {
            if (quantity <= 0)
            {
                throw new OrderingDomainException("Invalid number of units");
            }

            ProductId = productId;

            _mealName = productName;
            _unitPrice = unitPrice;
            _quantity = quantity;
        }

        public int GetQuantity() => _quantity;

        public decimal GetUnitPrice() => _unitPrice;

        public string GetOrderItemProductName() => _mealName;

        public void AddQuantity(int quantity)
        {
            if (quantity < 0)
            {
                throw new OrderingDomainException("Invalid quantity");
            }

            _quantity += quantity;
        }
    }
}
