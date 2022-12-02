using Foodie.Orders.Application.Contracts.Infrastructure.Repositories;
using Foodie.Orders.Domain.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.DomainEventsHandlers.ContractorVerified
{
    public class UpdateOrderWhenContractorVerifiedDomainEventHandler : INotificationHandler<ContractorVerifiedDomainEvent>
    {
        private readonly IOrdersRepository _ordersRepository;

        public UpdateOrderWhenContractorVerifiedDomainEventHandler(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public async Task Handle(ContractorVerifiedDomainEvent contractorVerifiedDomainEvent, CancellationToken cancellationToken)
        {
            var orderToUpdate = await _ordersRepository.GetByIdAsync(contractorVerifiedDomainEvent.OrderId);
            orderToUpdate.SetContractorId(contractorVerifiedDomainEvent.Contractor.Id);
        }
    }
}
