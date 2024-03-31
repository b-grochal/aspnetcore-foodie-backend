using Foodie.Common.Domain.Entities;
using Foodie.Common.Results;
using Foodie.Orders.Domain.Orders.Errors;
using System;

namespace Foodie.Orders.Domain.Orders.Entities
{
    public class OrderItem : DomainEntity
    {
        public string Name { get; }

        public decimal UnitPrice { get; }

        public int Quantity { get; private set; }

        public int MealId { get; }

        private OrderItem(int mealId, string name, decimal unitPrice, int quantity = 1)
        {
            if (quantity <= 0)
            {
                throw new ArgumentException("Quantity should be greater than zero.");
            }

            MealId = mealId;
            Name = name;
            UnitPrice = unitPrice;
            Quantity = quantity;
        }

        public static OrderItem Create(int mealId, string name, decimal unitPrice, int quantity = 1)
        {
            return new OrderItem(mealId, name, unitPrice, quantity);
        }

        public Result AddQuantity(int quantity)
        {
            if (quantity < 0)
            {
                return Result.Failure(OrderItemDomainErrors.QuantityLoweThanZero());
            }

            Quantity += quantity;

            return Result.Success();
        }
    }
}
