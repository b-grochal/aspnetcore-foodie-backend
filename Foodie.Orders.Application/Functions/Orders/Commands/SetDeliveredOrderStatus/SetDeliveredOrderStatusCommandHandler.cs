using Foodie.Orders.Application.Contracts.Infrastructure.Repositories;
using Foodie.Orders.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Functions.Orders.Commands.SetDeliveredOrderStatus
{
    public class SetDeliveredOrderStatusCommandHandler : IRequestHandler<SetDeliveredOrderStatusCommand>
    {
        private readonly IOrdersRepository _ordersRepository;

        public SetDeliveredOrderStatusCommandHandler(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public async Task<Unit> Handle(SetDeliveredOrderStatusCommand request, CancellationToken cancellationToken)
        {
            var order = await _ordersRepository.GetByIdAsync(request.Id);

            if (order == null)
                throw new OrderNotFoundException(request.Id);

            order.SetDeliveredStatus();
            await _ordersRepository.UnitOfWork.SaveEntitiesAsync();
            return Unit.Value;
        }
    }
}
