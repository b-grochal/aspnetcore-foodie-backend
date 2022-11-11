using Foodie.EventBus.IntegrationEvents.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.EventBus.IntegrationEvents.Orders
{
    public interface OrderStartedIntegrationEvent : IntegrationEvent
    {
        string UserId { get; set; }
    }
}
