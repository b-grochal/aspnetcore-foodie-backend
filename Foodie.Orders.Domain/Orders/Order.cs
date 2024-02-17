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

        public OrderStatus OrderStatus { get; private set; }

        public DeliveryAddress DeliveryAddress { get; }

        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();

        private Order() { }

        private Order(DeliveryAddress deliveryAddress, string customerEmail, int? buyerId = null, int? contractorId = null)
        {
            OrderStatus = OrderStatus.Started;
            DeliveryAddress = deliveryAddress;
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
            if (OrderStatus == OrderStatus.Started)
            {
                AddDomainEvent(new OrderStatusChangedToInProgressDomainEvent(this));
                OrderStatus = OrderStatus.InProgress;
            }
        }

        public void SetInDeliveryStatus()
        {
            if (OrderStatus == OrderStatus.InProgress)
            {
                AddDomainEvent(new OrderStatusChangedToInDeliveryDomainEvent(this));
                OrderStatus = OrderStatus.InDelivery;
            }
        }

        public void SetDeliveredStatus()
        {
            if (OrderStatus == OrderStatus.InDelivery)
            {
                AddDomainEvent(new OrderDeliveredDomainEvent(this));
                OrderStatus = OrderStatus.Delivered;
            }
        }

        public void SetCancelledStatus()
        {
            AddDomainEvent(new OrderCancelledDomainEvent(this));
            OrderStatus = OrderStatus.Cancelled;
        }

        public decimal GetTotal()
        {
            return _orderItems.Sum(i => i.Quantity * i.UnitPrice);
        }
    }
}
