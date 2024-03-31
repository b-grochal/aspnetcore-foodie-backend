using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Orders.Application.Contracts.Infrastructure.Database.Repositories;
using Foodie.Orders.Domain.Buyers;
using Foodie.Orders.Domain.Buyers.DomainEvents;
using Foodie.Orders.Domain.Orders.DomainEvents;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Features.Orders.DomainEventsHandlers.OrderStarted
{
    public class ValidateOrAddBuyerAggregateWhenOrderStartedDomainEventHandler : INotificationHandler<OrderStartedDomainEvent>
    {
        private readonly IBuyersRepository _buyersRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ValidateOrAddBuyerAggregateWhenOrderStartedDomainEventHandler(IBuyersRepository buyerRepository, IUnitOfWork unitOfWork)
        {
            _buyersRepository = buyerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(OrderStartedDomainEvent orderStartedDomainEvent, CancellationToken cancellationToken)
        {
            var buyer = await _buyersRepository.GetByCustomerIdAsync(orderStartedDomainEvent.CustomerId);
            bool buyerOriginallyExisted = buyer == null ? false : true;

            if (!buyerOriginallyExisted)
            {
                buyer = Buyer.Create(orderStartedDomainEvent.CustomerId, orderStartedDomainEvent.CustomerFirstName,
                    orderStartedDomainEvent.CustomerLastName, orderStartedDomainEvent.CustomerPhoneNumber, orderStartedDomainEvent.CustomerEmail);
            }

            var buyerUpdated = buyerOriginallyExisted ?
                _buyersRepository.Update(buyer) :
                _buyersRepository.Create(buyer);

            buyer.AddDomainEvent(new BuyerVerifiedDomainEvent(buyer, orderStartedDomainEvent.Order.Id));

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
