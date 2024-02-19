using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Orders.Application.Contracts.Infrastructure.Repositories;
using Foodie.Orders.Domain.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Functions.Orders.Commands.SetInDeliveryOrderStatus
{
    public class SetInDeliveryOrderStatusCommandHandler : IRequestHandler<SetInDeliveryOrderStatusCommand>
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SetInDeliveryOrderStatusCommandHandler(IOrdersRepository ordersRepository, IUnitOfWork unitOfWork)
        {
            _ordersRepository = ordersRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(SetInDeliveryOrderStatusCommand request, CancellationToken cancellationToken)
        {
            var order = await _ordersRepository.GetByIdAsync(request.Id);

            if (order == null)
                throw new OrderNotFoundException(request.Id);

            order.SetInDeliveryStatus();
            
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
