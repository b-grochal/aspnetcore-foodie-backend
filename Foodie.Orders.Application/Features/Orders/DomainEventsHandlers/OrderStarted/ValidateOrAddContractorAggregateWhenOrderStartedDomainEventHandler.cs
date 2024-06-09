using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Orders.Application.Contracts.Infrastructure.Database.Repositories;
using Foodie.Orders.Domain.Contractors;
using Foodie.Orders.Domain.Contractors.DomainEvents;
using Foodie.Orders.Domain.Orders.DomainEvents;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Features.Orders.DomainEventsHandlers.OrderStarted
{
    public class ValidateOrAddContractorAggregateWhenOrderStartedDomainEventHandler : INotificationHandler<OrderStartedDomainEvent>
    {
        private readonly IContractorsRepository _contractorsRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ValidateOrAddContractorAggregateWhenOrderStartedDomainEventHandler(IContractorsRepository contractorsRepository, IUnitOfWork unitOfWork)
        {
            _contractorsRepository = contractorsRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(OrderStartedDomainEvent orderStartedDomainEvent, CancellationToken cancellationToken)
        {
            var contractor = await _contractorsRepository.GetByParametersAsync(orderStartedDomainEvent.RestaurantId, orderStartedDomainEvent.LocationId, orderStartedDomainEvent.CityId);
            bool contractorOriginallyExisted = contractor == null ? false : true;

            if (!contractorOriginallyExisted)
            {
                contractor = Contractor.Create(orderStartedDomainEvent.RestaurantId, orderStartedDomainEvent.RestaurantName, orderStartedDomainEvent.LocationId,
                    orderStartedDomainEvent.LocationAddress, orderStartedDomainEvent.LocationPhoneNumber, orderStartedDomainEvent.LocationEmail,
                    orderStartedDomainEvent.CityId, orderStartedDomainEvent.CityName, orderStartedDomainEvent.CountryId, orderStartedDomainEvent.CountryName);
            }

            var contractorUpdated = contractorOriginallyExisted ?
                _contractorsRepository.Update(contractor) :
                _contractorsRepository.Create(contractor);

            contractor.AddDomainEvent(new ContractorVerifiedDomainEvent(contractor, orderStartedDomainEvent.Order.Id));

            await _unitOfWork.CommitChangesAsync(handlerName: GetType().Name, cancellationToken: cancellationToken);
        }
    }
}
