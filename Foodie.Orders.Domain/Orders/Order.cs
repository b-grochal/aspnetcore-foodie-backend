using Foodie.Common.Domain.AggregateRoots;
using Foodie.Orders.Domain.Orders.DomainEvents;
using Foodie.Orders.Domain.Orders.Entities;
using Foodie.Orders.Domain.Orders.Enumerations;
using Foodie.Orders.Domain.Orders.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace Foodie.Orders.Domain.Orders
{
    public class Order : AggregateRoot
    {
        private readonly List<OrderItem> _orderItems = new();

        public int? BuyerId { get; private set; }

        public int? ContractorId { get; private set; }

        public int OrderStatusId { get; private set; }

        public DeliveryAddress Address { get; }

        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();

        private Order(DeliveryAddress address, string customerEmail, int? buyerId = null, int? contractorId = null)
        {
            OrderStatusId = OrderStatus.Started.Id;
            Address = address;
            CreatedBy = customerEmail;
            BuyerId = buyerId;
            ContractorId = contractorId;
        }

        public static Order Create(string customerId, string customerFirstName, string customerLastName, string customerPhoneNumber, string customerEmail, int restaurantId, string restaurantName, int locationId, string locationAddress,
            string locationPhoneNumber, string locationEmail, int cityId, string cityName, int countryId, string countryName, DeliveryAddress deliveryAddress, int? buyerId = null, int? contractorId = null)
        {
            var order = new Order(deliveryAddress, customerEmail, buyerId, contractorId);

            order.AddDomainEvent(new OrderStartedDomainEvent(customerId, customerFirstName, customerLastName, customerPhoneNumber, customerEmail, restaurantId, restaurantName, locationId,
                locationAddress, locationPhoneNumber, locationEmail, cityId, cityName, countryId, countryName, order));

            return order;
        }

        public void AddOrderItem(int mealId, string mealName, decimal unitPrice, int quantity = 1)
        {
            var existingOrderForProduct = _orderItems.Where(o => o.MealId == mealId)
                .SingleOrDefault();

            if (existingOrderForProduct != null)
            {
                existingOrderForProduct.AddQuantity(quantity);
            }
            else
            {
                var orderItem = OrderItem.Create(mealId, mealName, unitPrice, quantity);
                _orderItems.Add(orderItem);
            }
        }

        public void SetBuyerId(int id)
        {
            BuyerId = id;
        }

        public void SetContractorId(int id)
        {
            ContractorId = id;
        }

        public void SetInProgressStatus()
        {
            if (OrderStatusId == OrderStatus.Started.Id)
            {
                AddDomainEvent(new OrderStatusChangedToInProgressDomainEvent(this));
                OrderStatusId = OrderStatus.InProgress.Id;
            }
        }

        public void SetInDeliveryStatus()
        {
            if (OrderStatusId == OrderStatus.InProgress.Id)
            {
                AddDomainEvent(new OrderStatusChangedToInDeliveryDomainEvent(this));
                OrderStatusId = OrderStatus.InDelivery.Id;
            }
        }

        public void SetDeliveredStatus()
        {
            if (OrderStatusId == OrderStatus.InDelivery.Id)
            {
                AddDomainEvent(new OrderDeliveredDomainEvent(this));
                OrderStatusId = OrderStatus.Delivered.Id;
            }
        }

        public void SetCancelledStatus()
        {
            AddDomainEvent(new OrderCancelledDomainEvent(this));
            OrderStatusId = OrderStatus.Cancelled.Id;
        }

        public decimal GetTotal()
        {
            return _orderItems.Sum(i => i.Quantity * i.UnitPrice);
        }
    }
}
