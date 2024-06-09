using Foodie.Common.Domain.AggregateRoots;
using Foodie.Common.Results;
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

        public Result AddOrderItem(int mealId, string mealName, decimal unitPrice, int quantity = 1)
        {
            var existingOrderForProduct = _orderItems.Where(o => o.MealId == mealId)
                .SingleOrDefault();

            if (existingOrderForProduct != null)
            {
                var result = existingOrderForProduct.AddQuantity(quantity);

                if(result.IsFailure)
                    return result;
            }
            else
            {
                var orderItem = OrderItem.Create(mealId, mealName, unitPrice, quantity);
                _orderItems.Add(orderItem);
            }

            return Result.Success();
        }

        public Result SetBuyerId(int id)
        {
            BuyerId = id;

            return Result.Success();
        }

        public Result SetContractorId(int id)
        {
            ContractorId = id;

            return Result.Success();
        }

        public Result SetInProgressStatus()
        {
            if (OrderStatus == OrderStatus.Started)
            {
                AddDomainEvent(new OrderStatusChangedToInProgressDomainEvent(this));
                OrderStatus = OrderStatus.InProgress;
            }

            return Result.Success();
        }

        public Result SetInDeliveryStatus()
        {
            if (OrderStatus == OrderStatus.InProgress)
            {
                AddDomainEvent(new OrderStatusChangedToInDeliveryDomainEvent(this));
                OrderStatus = OrderStatus.InDelivery;
            }

            return Result.Success();
        }

        public Result SetDeliveredStatus()
        {
            if (OrderStatus == OrderStatus.InDelivery)
            {
                AddDomainEvent(new OrderDeliveredDomainEvent(this));
                OrderStatus = OrderStatus.Delivered;
            }

            return Result.Success();
        }

        public Result SetCancelledStatus()
        {
            AddDomainEvent(new OrderCancelledDomainEvent(this));
            OrderStatus = OrderStatus.Cancelled;

            return Result.Success();
        }

        public decimal GetTotal()
        {
            return _orderItems.Sum(i => i.Quantity * i.UnitPrice);
        }
    }
}
