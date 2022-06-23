using Foodie.Orders.Domain.AggregatesModel.OrderAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Orders.Domain.Events
{
    public class OrderStartedDomainEvent : INotification
    {
        public string UserId { get; }
        public string UserEmail { get; }
        public Order Order { get; }

        public OrderStartedDomainEvent(Order order, string userId, string userEmail)
        {
            this.Order = order;
            this.UserId = userId;
            this.UserEmail = userEmail;
        }
    }
}
