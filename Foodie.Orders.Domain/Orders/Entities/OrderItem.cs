using Foodie.Common.Domain.Entities;
using Foodie.Orders.Domain.Exceptions;

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
                throw new OrderingDomainException("Invalid number of units");
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

        public void AddQuantity(int quantity)
        {
            if (quantity < 0)
            {
                throw new OrderingDomainException("Invalid quantity");
            }

            Quantity += quantity;
        }
    }
}
