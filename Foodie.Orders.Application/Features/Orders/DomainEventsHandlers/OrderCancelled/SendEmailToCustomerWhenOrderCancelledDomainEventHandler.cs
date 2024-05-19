using Foodie.Orders.Application.Contracts.Infrastructure.Database.Repositories;
using Foodie.Orders.Domain.Orders.DomainEvents;
using Foodie.Templates.Services;
using Hangfire;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Features.Orders.DomainEventsHandlers.OrderCancelled
{
    public class SendEmailToCustomerWhenOrderCancelledDomainEventHandler : INotificationHandler<OrderCancelledDomainEvent>
    {
        private readonly IBuyersRepository _buyersRepository;
        private readonly IEmailsService _emailsService;
        private readonly IBackgroundJobClient _backgroundJobClient;

        public SendEmailToCustomerWhenOrderCancelledDomainEventHandler(IBuyersRepository buyersRepository, IEmailsService emailsService, IBackgroundJobClient backgroundJobClient)
        {
            _buyersRepository = buyersRepository;
            _emailsService = emailsService;
            _backgroundJobClient = backgroundJobClient;
        }

        public async Task Handle(OrderCancelledDomainEvent notification, CancellationToken cancellationToken)
        {
            var buyer = await _buyersRepository.GetByIdAsync(notification.Order.BuyerId.Value);
            _backgroundJobClient.Enqueue(() => _emailsService.SendOrderCancelledEmail(buyer.Email, notification.Order.Id));
        }
    }
}
