using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Orders.Application.Contracts.Infrastructure.Database.Repositories;
using Foodie.Orders.Domain.Buyers.DomainEvents;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Features.Buyers.DomainEventsHandlers.BuyerVerified
{
    public class UpdateOrderWhenBuyerVerifiedDomainEventHandler : INotificationHandler<BuyerVerifiedDomainEvent>
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateOrderWhenBuyerVerifiedDomainEventHandler(IOrdersRepository ordersRepository, IUnitOfWork unitOfWork)
        {
            _ordersRepository = ordersRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(BuyerVerifiedDomainEvent buyerVerifiedDomainEvent, CancellationToken cancellationToken)
        {
            var orderToUpdate = await _ordersRepository.GetByIdAsync(buyerVerifiedDomainEvent.OrderId);
            orderToUpdate.SetBuyerId(buyerVerifiedDomainEvent.Buyer.Id);
            await _unitOfWork.CommitChangesAsync(handlerName: GetType().Name, cancellationToken: cancellationToken);
        }
    }
}
