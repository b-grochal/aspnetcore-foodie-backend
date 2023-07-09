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
        private readonly IEmailsService _emailsService;

        public SetInProgressOrderStatusCommandHandler(IOrdersRepository ordersRepository, IEmailsService emailsService)
        {
            _ordersRepository = ordersRepository;
            _emailsService = emailsService;
        }

        public async Task<Unit> Handle(SetInProgressOrderStatusCommand request, CancellationToken cancellationToken)
        {
            var order = await _ordersRepository.GetByIdAsync(request.Id);

            if (order == null)
                throw new OrderNotFoundException(request.Id);

            order.SetInProgressStatus();
            await _ordersRepository.UnitOfWork.SaveEntitiesAsync();

            return Unit.Value;
        }
    }
}
