using Foodie.Orders.Application.Contracts.Infrastructure.Repositories;
using Foodie.Orders.Domain.Buyers;
using Foodie.Orders.Domain.Buyers.DomainEvents;
using Foodie.Orders.Domain.Orders.DomainEvents;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.DomainEventsHandlers.OrderStarted
{
    public class ValidateOrAddBuyerAggregateWhenOrderStartedDomainEventHandler : INotificationHandler<OrderStartedDomainEvent>
    {
        private readonly IBuyersRepository _buyersRepository;

        public ValidateOrAddBuyerAggregateWhenOrderStartedDomainEventHandler(IBuyersRepository buyerRepository)
        {
            _buyersRepository = buyerRepository;
        }

        public async Task Handle(OrderStartedDomainEvent orderStartedDomainEvent, CancellationToken cancellationToken)
        {
            var buyer = await _buyersRepository.GetByCustomerIdAsync(orderStartedDomainEvent.CustomerId);
            bool buyerOriginallyExisted = (buyer == null) ? false : true;

            if (!buyerOriginallyExisted)
            {
                buyer = Buyer.Create(orderStartedDomainEvent.CustomerId, orderStartedDomainEvent.CustomerFirstName, orderStartedDomainEvent.CustomerLastName, orderStartedDomainEvent.CustomerPhoneNumber, orderStartedDomainEvent.CustomerEmail);
            }

            var buyerUpdated = buyerOriginallyExisted ?
                _buyersRepository.Update(buyer) :
                _buyersRepository.Create(buyer);

            buyer.AddDomainEvent(new BuyerVerifiedDomainEvent(buyer, orderStartedDomainEvent.Order.Id));

            await _buyersRepository.UnitOfWork
                .SaveEntitiesAsync(cancellationToken);
        }
    }
}
