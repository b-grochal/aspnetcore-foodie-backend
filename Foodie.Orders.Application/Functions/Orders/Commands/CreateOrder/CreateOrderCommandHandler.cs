﻿using Foodie.EventBus.IntegrationEvents.Orders;
using Foodie.Orders.Application.Contracts.Infrastructure.Repositories;
using Foodie.Orders.Domain.Orders;
using Foodie.Orders.Domain.Orders.ValueObjects;
using MassTransit;
using MediatR;
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
            await _publishEndpoint.Publish<OrderStartedIntegrationEvent>(new
            {
                UserId = request.CustomerId
            });

            var address = DeliveryAddress.Create(request.AddressStreet, request.AddressCity, request.AddressCountry);
            var order = Order.Create(request.CustomerId, request.CustomerFirstName, request.CustomerLastName, request.CustomerPhoneNumber, request.CustomerEmail, request.RestaurantId, request.RestaurantName,
                request.LocationId, request.LocationAddress, request.LocationPhoneNumber, request.LocationEmail, request.CityId, request.CityName, request.CountryId, request.CountryName, address);

            foreach (var item in request.OrderItems)
            {
                order.AddOrderItem(item.MealId, item.MealName, item.UnitPrice, item.Quantity);
            }

            _ordersRepository.Create(order);

            await _ordersRepository.UnitOfWork.SaveEntitiesAsync();

            return Unit.Value;
        }
    }
}
