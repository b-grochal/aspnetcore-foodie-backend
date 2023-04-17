using Foodie.Basket.Repositories.Interfaces;
using Foodie.EventBus.IntegrationEvents.Basket;
using IdentityGrpc;
using MassTransit;
using MealsGrpc;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Basket.API.Functions.CustomerBaskets.Commands.CheckoutCustomerBasket
{
    public class CheckoutCustomerBasketCommandHandler : IRequestHandler<CheckoutCustomerBasketCommand>
    {
        private readonly ICustomerBasketsRepository customerBasketsRepository;
        private readonly IdentityService.IdentityServiceClient identityServiceClient;
        private readonly MealsService.MealsServiceClient mealsServiceClient;
        private readonly IPublishEndpoint publishEndpoint;

        public CheckoutCustomerBasketCommandHandler(ICustomerBasketsRepository customerBasketsRepository, IdentityService.IdentityServiceClient identityServiceClient, MealsService.MealsServiceClient mealsServiceClient, IPublishEndpoint publishEndpoint)
        {
            this.customerBasketsRepository = customerBasketsRepository;
            this.identityServiceClient = identityServiceClient;
            this.mealsServiceClient = mealsServiceClient;
            this.publishEndpoint = publishEndpoint;
        }

        public async Task<Unit> Handle(CheckoutCustomerBasketCommand request, CancellationToken cancellationToken)
        {
            var customerBasket = await customerBasketsRepository.GetByCustomerId(request.CustomerId);

            var identityServiceRequest = new GetCustomerRequest { Id = request.CustomerId };
            var identityCall = await identityServiceClient.GetCustomerAsync(identityServiceRequest);
            var customer = identityCall.Customer;

            var mealsServiceRequest = new GetLocationRequest { Id = customerBasket.LocationId };
            var mealsCall = await mealsServiceClient.GetLocationAsync(mealsServiceRequest);
            var location = mealsCall.Location;

            await publishEndpoint.Publish<CustomerCheckoutIntegrationEvent>(new
            {
                CustomerId = "6a1ab648-6be8-44f1-87b7-394c34547589",
                CustomerFirstName = customer.FirstName,
                CustomerLastName = customer.LastName,
                CustomerPhoneNumber = customer.PhoneNumber,
                CustomerEmail = customer.Email,
                AddressStreet = request.Address,
                AddressCity = location.CityName,
                AddressCountry = location.CityCountry,
                RestaurantId = location.RestaurantId,
                RestaurantName = location.RestaurantName,
                LocationId = location.Id,
                LocationAddress = location.Address,
                LocationPhoneNumber = location.PhoneNumber,
                LocationEmail = location.Email,
                CityId = location.CityId,
                CityName = location.CityName,
                LocationCountry = location.CityCountry,
                OrderItems = customerBasket.Items.Select(i =>
                new
                {
                    MealId = i.MealId,
                    MealName = i.MealName,
                    UnitPrice = i.UnitPrice,
                    Quantity = i.Quantity
                })
            });

            return Unit.Value;
        }
    }
}
