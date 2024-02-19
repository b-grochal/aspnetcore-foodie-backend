using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Orders.Application.Contracts.Infrastructure.Repositories;
using Foodie.Orders.Domain.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Functions.Orders.Commands.SetDeliveredOrderStatus
{
    public class SetDeliveredOrderStatusCommandHandler : IRequestHandler<SetDeliveredOrderStatusCommand>
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SetDeliveredOrderStatusCommandHandler(IOrdersRepository ordersRepository, IUnitOfWork unitOfWork)
        {
            _ordersRepository = ordersRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(SetDeliveredOrderStatusCommand request, CancellationToken cancellationToken)
        {
            var order = await _ordersRepository.GetByIdAsync(request.Id);

            if (order == null)
                throw new OrderNotFoundException(request.Id);

            order.SetDeliveredStatus();

            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
