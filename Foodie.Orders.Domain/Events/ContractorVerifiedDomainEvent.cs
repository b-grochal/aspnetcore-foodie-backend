using Foodie.Orders.Domain.AggregatesModel.ContractorAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Orders.Domain.Events
{
    public class ContractorVerifiedDomainEvent : INotification
    {
        public Contractor Contractor { get; private set; }
        public int OrderId { get; private set; }

        public ContractorVerifiedDomainEvent(Contractor contractor, int orderId)
        {
            Contractor = contractor;
            OrderId = orderId;
        }
    }
}
