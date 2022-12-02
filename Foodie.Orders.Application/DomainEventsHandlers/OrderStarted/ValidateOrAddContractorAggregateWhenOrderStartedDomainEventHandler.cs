using Foodie.Orders.Application.Contracts.Infrastructure.Repositories;
using Foodie.Orders.Domain.AggregatesModel.ContractorAggregate;
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
    public class ValidateOrAddContractorAggregateWhenOrderStartedDomainEventHandler : INotificationHandler<OrderStartedDomainEvent>
    {
        private readonly IContractorsRepository _contractorsRepository;

        public ValidateOrAddContractorAggregateWhenOrderStartedDomainEventHandler(IContractorsRepository contractorsRepository)
        {
            _contractorsRepository = contractorsRepository;
        }

        public async Task Handle(OrderStartedDomainEvent orderStartedDomainEvent, CancellationToken cancellationToken)
        {
            var contractor = await _contractorsRepository.GetByParametersAsync(orderStartedDomainEvent.RestaurantId, orderStartedDomainEvent.LocationId, orderStartedDomainEvent.CityId);
            bool contractorOriginallyExisted = (contractor == null) ? false : true;

            if (!contractorOriginallyExisted)
            {
                contractor = new Contractor(orderStartedDomainEvent.RestaurantId, orderStartedDomainEvent.RestaurantName, orderStartedDomainEvent.LocationId, orderStartedDomainEvent.LocationAddress, orderStartedDomainEvent.LocationPhoneNumber, orderStartedDomainEvent.LocationEmail, orderStartedDomainEvent.CityId, orderStartedDomainEvent.CityName, orderStartedDomainEvent.LocationCountry);
            }

            var contractorUpdated = contractorOriginallyExisted ?
                _contractorsRepository.Update(contractor) :
                _contractorsRepository.Create(contractor);

            contractor.AddDomainEvent(new ContractorVerifiedDomainEvent(contractor, orderStartedDomainEvent.Order.Id));

            await _contractorsRepository.UnitOfWork
                .SaveEntitiesAsync(cancellationToken);
        }
    }
}
