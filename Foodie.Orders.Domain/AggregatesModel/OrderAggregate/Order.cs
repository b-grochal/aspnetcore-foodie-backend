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
        private DateTime orderDate;
        public Address Address { get; private set; }

        public int? GetBuyerId => buyerId;
        private int? buyerId;

        public OrderStatus OrderStatus { get; private set; }
        private int orderStatusId;

        private readonly List<OrderItem> orderItems;
        public IReadOnlyCollection<OrderItem> OrderItems => orderItems;

        protected Order()
        {
            orderItems = new List<OrderItem>();
        }

        public Order(string userId, string userEmail, Address address, int? buyerId) : this()
        {
            this.buyerId = buyerId;
            this.orderStatusId = OrderStatus.Started.Id;
            this.orderDate = DateTime.UtcNow;
            this.Address = address;

            AddOrderStartedDomainEvent(userId, userEmail);
        }

        public void AddOrderItem(int productId, string productName, decimal unitPrice, int units = 1)
        {
            var existingOrderForProduct = orderItems.Where(o => o.ProductId == productId)
                .SingleOrDefault();

            if (existingOrderForProduct != null)
            {
                existingOrderForProduct.AddUnits(units);
            }
            else
            {
                var orderItem = new OrderItem(productId, productName, unitPrice, units);
                orderItems.Add(orderItem);
            }
        }

        private void AddOrderStartedDomainEvent(string userId, string userName)
        {
            var orderStartedDomainEvent = new OrderStartedDomainEvent(this, userId, userName);
            this.AddDomainEvent(orderStartedDomainEvent);
        }

        public void SetInProgressStatus()
        {
            if (this.orderStatusId == OrderStatus.Started.Id)
            {
                AddDomainEvent(new OrderStatusChangedToInProgressDomainEvent(this));
                orderStatusId = OrderStatus.InProgress.Id;
            }
        }

        public void SetInDeliveryStatus()
        {
            if (orderStatusId == OrderStatus.InProgress.Id)
            {
                AddDomainEvent(new OrderStatusChangedToInDeliveryDomainEvent(this));
                orderStatusId = OrderStatus.InDelivery.Id;
            }
        }

        public void SetDeliveredStatus()
        {
            if (orderStatusId == OrderStatus.InDelivery.Id)
            {
                AddDomainEvent(new OrderDeliveredDomainEvent(this));
                orderStatusId = OrderStatus.Delivered.Id;
            }
        }

        public void SetCancelledStatus()
        {
                AddDomainEvent(new OrderCancelledDomainEvent(this));
                orderStatusId = OrderStatus.Cancelled.Id;
        }

        public decimal GetTotal()
        {
            return orderItems.Sum(o => o.GetUnits() * o.GetUnitPrice());
        }

    }
}
