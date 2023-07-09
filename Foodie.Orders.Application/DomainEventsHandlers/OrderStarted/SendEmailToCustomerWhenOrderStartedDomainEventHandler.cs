using Foodie.Orders.Application.Contracts.Infrastructure.Repositories;
using Foodie.Orders.Domain.Events;
using Foodie.Templates.Services;
using Hangfire;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.DomainEventsHandlers.OrderStarted
{
    public class SendEmailToCustomerWhenOrderStartedDomainEventHandler : INotificationHandler<OrderStartedDomainEvent>
    {
        private readonly IBuyersRepository _buyersRepository;
        private readonly IEmailsService _emailsService;
        private readonly IBackgroundJobClient _backgroundJobClient;

        public SendEmailToCustomerWhenOrderStartedDomainEventHandler(IBuyersRepository buyersRepository, IEmailsService emailsService, IBackgroundJobClient backgroundJobClient)
        {
            _buyersRepository = buyersRepository;
            _emailsService = emailsService;
            _backgroundJobClient = backgroundJobClient;
        }

        public async Task Handle(OrderStartedDomainEvent notification, CancellationToken cancellationToken)
        {
            _backgroundJobClient.Enqueue(() => _emailsService.SendOrderStartedEmail(notification.CustomerEmail, notification.Order.Id));
        }
    }
}
