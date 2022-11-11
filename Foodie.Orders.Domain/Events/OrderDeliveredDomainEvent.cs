using Foodie.Orders.Domain.AggregatesModel.OrderAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Orders.Domain.Events
{
    public class OrderDeliveredDomainEvent : INotification
    {
        public Order Order { get; }

        public OrderDeliveredDomainEvent(Order order)
        {
            this.Order = order;
        }
    }
}
