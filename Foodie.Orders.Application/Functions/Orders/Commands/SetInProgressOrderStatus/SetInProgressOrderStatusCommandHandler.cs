using Foodie.Orders.Application.Contracts.Infrastructure.Repositories;
using Foodie.Orders.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Functions.Orders.Commands.SetInProgressOrderStatus
{
    public class SetInProgressOrderStatusCommandHandler : IRequestHandler<SetInProgressOrderStatusCommand>
    {
        private readonly IOrdersRepository _ordersRepository;

        public SetInProgressOrderStatusCommandHandler(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public async Task<Unit> Handle(SetInProgressOrderStatusCommand request, CancellationToken cancellationToken)
        {
            var order = await _ordersRepository.GetByIdAsync(request.OrderId);

            if (order == null)
                throw new OrderingDomainException($"The order with the indetifier {request.OrderId} was not found.");

            order.SetInProgressStatus();
            await _ordersRepository.UnitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
