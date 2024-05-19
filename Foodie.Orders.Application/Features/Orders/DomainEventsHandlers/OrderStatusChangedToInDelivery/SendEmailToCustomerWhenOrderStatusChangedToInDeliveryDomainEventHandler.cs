using Foodie.Orders.Application.Contracts.Infrastructure.Database.Repositories;
using Foodie.Orders.Domain.Orders.DomainEvents;
using Foodie.Templates.Services;
using Hangfire;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Features.Orders.DomainEventsHandlers.OrderStatusChangedToInDelivery
{
    public class SendEmailToCustomerWhenOrderStatusChangedToInDeliveryDomainEventHandler : INotificationHandler<OrderStatusChangedToInDeliveryDomainEvent>
    {
        private readonly IBuyersRepository _buyersRepository;
        private readonly IEmailsService _emailsService;
        private readonly IBackgroundJobClient _backgroundJobClient;

        public SendEmailToCustomerWhenOrderStatusChangedToInDeliveryDomainEventHandler(IBuyersRepository buyersRepository, IEmailsService emailsService, IBackgroundJobClient backgroundJobClient)
        {
            _buyersRepository = buyersRepository;
            _emailsService = emailsService;
            _backgroundJobClient = backgroundJobClient;
        }

        public async Task Handle(OrderStatusChangedToInDeliveryDomainEvent notification, CancellationToken cancellationToken)
        {
            var buyer = await _buyersRepository.GetByIdAsync(notification.Order.BuyerId.Value);
            _backgroundJobClient.Enqueue(() => _emailsService.SendOrderInDeliveryEmail(buyer.Email, notification.Order.Id));
        }
    }
}
