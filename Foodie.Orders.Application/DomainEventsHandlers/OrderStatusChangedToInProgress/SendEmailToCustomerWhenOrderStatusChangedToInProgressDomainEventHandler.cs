using Foodie.Orders.Application.Contracts.Infrastructure.Repositories;
using Foodie.Orders.Domain.Events;
using Foodie.Templates.Services;
using Hangfire;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.DomainEventsHandlers.OrderStatusChangedToInProgress
{
    public class SendEmailToCustomerWhenOrderStatusChangedToInProgressDomainEventHandler : INotificationHandler<OrderStatusChangedToInProgressDomainEvent>
    {
        private readonly IBuyersRepository _buyersRepository;
        private readonly IEmailsService _emailsService;
        private readonly IBackgroundJobClient _backgroundJobClient;

        public SendEmailToCustomerWhenOrderStatusChangedToInProgressDomainEventHandler(IBuyersRepository buyersRepository, IEmailsService emailsService, IBackgroundJobClient backgroundJobClient)
        {
            _buyersRepository = buyersRepository;
            _emailsService = emailsService;
            _backgroundJobClient = backgroundJobClient;
        }

        public async Task Handle(OrderStatusChangedToInProgressDomainEvent notification, CancellationToken cancellationToken)
        {
            var buyer = await _buyersRepository.GetByIdAsync(notification.Order.GetBuyerId.Value);
            _backgroundJobClient.Enqueue(() => _emailsService.SendOrderInProgressEmail(buyer.Email, notification.Order.Id));
        }
    }
}
