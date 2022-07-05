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

        public Order(string userId, string userEmail, Address address, int? buyerId) : this()
        {
            _buyerId = buyerId;
            _orderStatusId = OrderStatus.Started.Id;
            _orderDate = DateTime.UtcNow;
            Address = address;

            AddOrderStartedDomainEvent(userId, userEmail);
        }

        public void AddOrderItem(int productId, string productName, decimal unitPrice, int units = 1)
        {
            var existingOrderForProduct = _orderItems.Where(o => o.ProductId == productId)
                .SingleOrDefault();

            if (existingOrderForProduct != null)
            {
                existingOrderForProduct.AddQuantity(units);
            }
            else
            {
                var orderItem = new OrderItem(productId, productName, unitPrice, units);
                _orderItems.Add(orderItem);
            }
        }

        private void AddOrderStartedDomainEvent(string userId, string userName)
        {
            var orderStartedDomainEvent = new OrderStartedDomainEvent(this, userId, userName);
            AddDomainEvent(orderStartedDomainEvent);
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

    }
}
