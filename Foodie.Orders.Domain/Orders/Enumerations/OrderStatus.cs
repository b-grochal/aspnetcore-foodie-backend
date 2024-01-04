using Foodie.Common.Domain.Enumerations;
using Foodie.Orders.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Foodie.Orders.Domain.Orders.Enumerations
{
    public class OrderStatus : Enumeration
    {
        public static OrderStatus Started = new OrderStatus(1, nameof(Started).ToLowerInvariant());
        public static OrderStatus InProgress = new OrderStatus(2, nameof(InProgress).ToLowerInvariant());
        public static OrderStatus InDelivery = new OrderStatus(3, nameof(InDelivery).ToLowerInvariant());
        public static OrderStatus Delivered = new OrderStatus(4, nameof(Delivered).ToLowerInvariant());
        public static OrderStatus Cancelled = new OrderStatus(5, nameof(Cancelled).ToLowerInvariant());

        public OrderStatus(int id, string name) : base(id, name) { }

        public static IEnumerable<OrderStatus> List() => new[] { Started, InProgress, InDelivery, Delivered, Cancelled };

        public static OrderStatus FromName(string name)
        {
            var state = List()
                .SingleOrDefault(s => String.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

            if (state == null)
            {
                throw new OrderingDomainException($"Possible values for OrderStatus: {String.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }

        public static OrderStatus From(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);

            if (state == null)
            {
                throw new OrderingDomainException($"Possible values for OrderStatus: {String.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }
    }
}
