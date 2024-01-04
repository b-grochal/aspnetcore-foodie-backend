using Foodie.Common.Domain.AggregateRoots;
using Foodie.Orders.Domain.Events;
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

        public DeliveryAddress Address { get; private set; }

        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();

        public Order(string userId, string userFirstName, string userLastName, string userPhoneNumber, string userEmail, int restaurantId, string restaurantName, int locationId, string locationAddress,
            string locationPhoneNumber, string locationEmail, int cityId, string cityName, string locationCountry, DeliveryAddress address, int? buyerId = null, int? contractorId = null)
        {
            BuyerId = buyerId;
            ContractorId = contractorId;
            OrderStatusId = OrderStatus.Started.Id;
            Address = address;

            AddOrderStartedDomainEvent(userId, userFirstName, userLastName, userPhoneNumber, userEmail, restaurantId, restaurantName, locationId,
                locationAddress, locationPhoneNumber, locationEmail, cityId, cityName, locationCountry);
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
                var orderItem = new OrderItem(mealId, mealName, unitPrice, quantity);
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

        private void AddOrderStartedDomainEvent(string customerId, string customerFirstName, string customerLastName, string customerPhoneNumber, string customerEmail, int restaurantId, string restaurantName, int locationId,
                string locationAddress, string locationPhoneNumber, string locationEmail, int cityId, string cityName, string locationCountry)
        {
            var orderStartedDomainEvent = new OrderStartedDomainEvent(customerId, customerFirstName, customerLastName, customerPhoneNumber, customerEmail, restaurantId, restaurantName, locationId,
                locationAddress, locationPhoneNumber, locationEmail, cityId, cityName, locationCountry, this);
            AddDomainEvent(orderStartedDomainEvent);
        }
    }
}
