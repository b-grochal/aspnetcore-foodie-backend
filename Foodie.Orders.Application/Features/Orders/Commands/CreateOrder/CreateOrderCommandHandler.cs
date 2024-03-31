using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Common.Results;
using Foodie.EventBus.IntegrationEvents.Orders;
using Foodie.Orders.Application.Contracts.Infrastructure.Database.Repositories;
using Foodie.Orders.Domain.Orders;
using Foodie.Orders.Domain.Orders.ValueObjects;
using MassTransit;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Result>
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;

        public CreateOrderCommandHandler(IOrdersRepository ordersRepository, IPublishEndpoint publishEndpoint, IMediator mediator, IUnitOfWork unitOfWork)
        {
            _ordersRepository = ordersRepository;
            _publishEndpoint = publishEndpoint;
            _mediator = mediator;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
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
                var result = order.AddOrderItem(item.MealId, item.MealName, item.UnitPrice, item.Quantity);

                if(result.IsFailure)
                    return result;
            }

            _ordersRepository.Create(order);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }
    }
}
