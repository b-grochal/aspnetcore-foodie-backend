using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Orders.Application.Contracts.Infrastructure.Database.Repositories;
using Foodie.Orders.Domain.Contractors.DomainEvents;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Features.Contractors.DomainEventsHandlers.ContractorVerified
{
    public class UpdateOrderWhenContractorVerifiedDomainEventHandler : INotificationHandler<ContractorVerifiedDomainEvent>
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateOrderWhenContractorVerifiedDomainEventHandler(IOrdersRepository ordersRepository, IUnitOfWork unitOfWork)
        {
            _ordersRepository = ordersRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(ContractorVerifiedDomainEvent contractorVerifiedDomainEvent, CancellationToken cancellationToken)
        {
            var orderToUpdate = await _ordersRepository.GetByIdAsync(contractorVerifiedDomainEvent.OrderId);
            orderToUpdate.SetContractorId(contractorVerifiedDomainEvent.Contractor.Id);
            await _unitOfWork.CommitChangesAsync(handlerName: GetType().Name, cancellationToken: cancellationToken);
        }
    }
}
