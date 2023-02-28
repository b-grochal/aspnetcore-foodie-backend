using Foodie.Orders.Application.Contracts.Infrastructure.Repositories;
using Foodie.Orders.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Functions.Orders.Commands.SetInDeliveryOrderStatus
{
    public class SetInDeliveryOrderStatusCommandHandler : IRequestHandler<SetInDeliveryOrderStatusCommand>
    {
        private readonly IOrdersRepository _ordersRepository;

        public SetInDeliveryOrderStatusCommandHandler(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public async Task<Unit> Handle(SetInDeliveryOrderStatusCommand request, CancellationToken cancellationToken)
        {
            var order = await _ordersRepository.GetByIdAsync(request.OrderId);

            if (order == null)
                throw new OrderNotFoundException(request.OrderId);

            order.SetInDeliveryStatus();
            await _ordersRepository.UnitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
