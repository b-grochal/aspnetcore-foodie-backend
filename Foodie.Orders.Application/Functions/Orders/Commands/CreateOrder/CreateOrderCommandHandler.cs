using Foodie.Orders.Application.Contracts.Infrastructure.Repositories;
using Foodie.Orders.Domain.AggregatesModel.OrderAggregate;
using MassTransit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Functions.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IMediator _mediator;

        public CreateOrderCommandHandler(IOrdersRepository ordersRepository, IPublishEndpoint publishEndpoint, IMediator mediator)
        {
            _ordersRepository = ordersRepository;
            _publishEndpoint = publishEndpoint;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            await _publishEndpoint.

            var address = new Address(request.AddressStreet, request.AddressCity, request.AddressCountry);
            var order = new Order(request.UserId, request.UserEmail, address);
            throw new NotImplementedException();
        }
    }
}
