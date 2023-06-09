using Foodie.Basket.Repositories.Interfaces;
using Foodie.EventBus.IntegrationEvents.Orders;
using MassTransit;
using System.Threading.Tasks;

namespace Foodie.Basket.API.IntegrationEventsHandlers
{
    public class OrderStartedIntegrationEventHandler : IConsumer<OrderStartedIntegrationEvent>
    {
        private readonly ICustomerBasketsRepository basketRepository;

        public OrderStartedIntegrationEventHandler(ICustomerBasketsRepository basketRepository)
        {
            this.basketRepository = basketRepository;
        }

        public async Task Consume(ConsumeContext<OrderStartedIntegrationEvent> context)
        {
            var message = context.Message;
            await basketRepository.DeleteBasket(int.Parse(message.UserId));
        }
    }
}
