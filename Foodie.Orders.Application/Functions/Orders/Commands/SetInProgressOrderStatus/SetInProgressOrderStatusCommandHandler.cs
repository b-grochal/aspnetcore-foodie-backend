using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Orders.Application.Contracts.Infrastructure.Repositories;
using Foodie.Orders.Domain.Exceptions;
using Foodie.Templates.Services;
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
        private readonly IUnitOfWork _unitOfWork;

        public SetInProgressOrderStatusCommandHandler(IOrdersRepository ordersRepository, IUnitOfWork unitOfWork)
        {
            _ordersRepository = ordersRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(SetInProgressOrderStatusCommand request, CancellationToken cancellationToken)
        {
            var order = await _ordersRepository.GetByIdAsync(request.Id);

            if (order == null)
                throw new OrderNotFoundException(request.Id);

            order.SetInProgressStatus();
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
