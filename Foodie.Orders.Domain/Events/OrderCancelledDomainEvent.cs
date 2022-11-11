using Foodie.Orders.Domain.AggregatesModel.OrderAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Orders.Domain.Events
{
    public class OrderCancelledDomainEvent : INotification
    {
        public Order Order { get; }

        public OrderCancelledDomainEvent(Order order)
        {
            this.Order = order;
        }
    }
}
