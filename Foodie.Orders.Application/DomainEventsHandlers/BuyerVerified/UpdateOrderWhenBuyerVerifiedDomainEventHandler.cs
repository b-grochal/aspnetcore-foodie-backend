using Foodie.Orders.Application.Contracts.Infrastructure.Repositories;
using Foodie.Orders.Domain.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.DomainEventsHandlers.BuyerVerified
{
    public class UpdateOrderWhenBuyerVerifiedDomainEventHandler : INotificationHandler<BuyerVerifiedDomainEvent>
    {
        private readonly IOrdersRepository _ordersRepository;

        public UpdateOrderWhenBuyerVerifiedDomainEventHandler(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public async Task Handle(BuyerVerifiedDomainEvent buyerVerifiedDomainEvent, CancellationToken cancellationToken)
        {
            var orderToUpdate = await _ordersRepository.GetByIdAsync(buyerVerifiedDomainEvent.OrderId);
            orderToUpdate.SetBuyerId(buyerVerifiedDomainEvent.Buyer.Id);
        }
    }
}
