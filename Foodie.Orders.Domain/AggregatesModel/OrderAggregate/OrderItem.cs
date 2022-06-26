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
        private int _units;

        public int ProductId { get; private set; }

        protected OrderItem() { }

        public OrderItem(int productId, string productName, decimal unitPrice, int units = 1)
        {
            if (units <= 0)
            {
                throw new OrderingDomainException("Invalid number of units");
            }

            ProductId = productId;

            _mealName = productName;
            _unitPrice = unitPrice;
            _units = units;
        }

        public int GetUnits() => _units;

        public decimal GetUnitPrice() => _unitPrice;

        public string GetOrderItemProductName() => _mealName;

        public void AddUnits(int units)
        {
            if (units < 0)
            {
                throw new OrderingDomainException("Invalid units");
            }

            _units += units;
        }
    }
}
