using Foodie.EventBus.IntegrationEvents.Basket;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.IntegrationEventsHandlers
{
    public class CustomerCheckoutIntegrationEventHandler : IConsumer<CustomerCheckoutIntegrationEvent>
    {
        public async Task Consume(ConsumeContext<CustomerCheckoutIntegrationEvent> context)
        {
            Console.WriteLine("Handling CustomerCheckoutIntegrationEvent");
        }
    }
}
