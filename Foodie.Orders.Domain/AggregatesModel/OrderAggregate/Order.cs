using Foodie.Orders.Domain.Events;
using Foodie.Orders.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Orders.Domain.AggregatesModel.OrderAggregate
{
    public class Order : Entity, IAggregateRoot
    {
        private DateTime _orderDate;
        public Address Address { get; private set; }

        public int? GetBuyerId => _buyerId;
        private int? _buyerId;

        private int? GetContractorId => _contractorId;
        private int? _contractorId;

        public OrderStatus OrderStatus { get; private set; }
        private int _orderStatusId;

        private readonly List<OrderItem> _orderItems;
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;

        protected Order()
        {
            _orderItems = new List<OrderItem>();
        }

        public Order(string userId, string userFirstName, string userLastName, string userPhoneNumber, string userEmail, int restaurantId, string restaurantName, int locationId, string locationAddress,
            string locationPhoneNumber, string locationEmail, int cityId, string cityName, string locationCountry, Address address, int? buyerId = null, int? contractorId = null) : this()
        {
            _buyerId = buyerId;
            _contractorId = contractorId;
            _orderStatusId = OrderStatus.Started.Id;
            _orderDate = DateTime.UtcNow;
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
            _buyerId = id;
        }

        public void SetContractorId(int id)
        {
            _contractorId = id;
        }

        public void SetInProgressStatus()
        {
            if (this._orderStatusId == OrderStatus.Started.Id)
            {
                AddDomainEvent(new OrderStatusChangedToInProgressDomainEvent(this));
                _orderStatusId = OrderStatus.InProgress.Id;
            }
        }

        public void SetInDeliveryStatus()
        {
            if (_orderStatusId == OrderStatus.InProgress.Id)
            {
                AddDomainEvent(new OrderStatusChangedToInDeliveryDomainEvent(this));
                _orderStatusId = OrderStatus.InDelivery.Id;
            }
        }

        public void SetDeliveredStatus()
        {
            if (_orderStatusId == OrderStatus.InDelivery.Id)
            {
                AddDomainEvent(new OrderDeliveredDomainEvent(this));
                _orderStatusId = OrderStatus.Delivered.Id;
            }
        }

        public void SetCancelledStatus()
        {
                AddDomainEvent(new OrderCancelledDomainEvent(this));
                _orderStatusId = OrderStatus.Cancelled.Id;
        }

        public decimal GetTotal()
        {
            return _orderItems.Sum(o => o.GetQuantity() * o.GetUnitPrice());
        }

        private void AddOrderStartedDomainEvent(string userId, string userFirstName, string userLastName, string userPhoneNumber, string userEmail, int restaurantId, string restaurantName, int locationId,
                string locationAddress, string locationPhoneNumber, string locationEmail, int cityId, string cityName, string locationCountry)
        {
            var orderStartedDomainEvent = new OrderStartedDomainEvent(userId, userFirstName, userLastName, userPhoneNumber, userEmail, restaurantId, restaurantName, locationId,
                locationAddress, locationPhoneNumber, locationEmail, cityId, cityName, locationCountry, this);
            AddDomainEvent(orderStartedDomainEvent);
        }
    }
}
