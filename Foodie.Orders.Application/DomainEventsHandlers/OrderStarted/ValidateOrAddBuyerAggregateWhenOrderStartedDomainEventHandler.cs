using Foodie.Orders.Application.Contracts.Infrastructure.Repositories;
using Foodie.Orders.Domain.AggregatesModel.BuyerAggregate;
using Foodie.Orders.Domain.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var buyer = await _buyersRepository.GetByUserIdAsync(orderStartedDomainEvent.UserId);
            bool buyerOriginallyExisted = (buyer == null) ? false : true;

            if (!buyerOriginallyExisted)
            {
                buyer = new Buyer(orderStartedDomainEvent.UserId, orderStartedDomainEvent.UserFirstName, orderStartedDomainEvent.UserLastName, orderStartedDomainEvent.UserPhoneNumber, orderStartedDomainEvent.UserEmail);
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
