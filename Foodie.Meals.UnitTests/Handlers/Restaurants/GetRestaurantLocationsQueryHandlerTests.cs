using AutoMapper;
using Foodie.Meals.Application.Functions.Restaurants.Queries.GetRestaurantLocations;
using Foodie.Meals.Application.Mapper;
using Foodie.Meals.UnitTests.Mocks.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Foodie.Meals.UnitTests.Handlers.Restaurants
{
    public class GetRestaurantLocationsQueryHandlerTests
    {
        private readonly IMapper mapper;

        public GetRestaurantLocationsQueryHandlerTests()
        {
            var mapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile<MapperProfile>();
            });

            this.mapper = mapperConfiguration.CreateMapper();
        }

        [Fact]
        public async void GetRestaurantLocationsQueryHandler_HandleFetchingAllRestaurantLocations_ShouldSucessfullyFetchRestaurantLocations()
        {
            var locationsRepository = new MockLocationsRepository()
                .MockGetAllAsyncForRestaurant();

            var query = new GetRestaurantLocationsQuery(1, 1);

            var queryHandler = new GetRestaurantLocationsQueryHandler(locationsRepository.Object, this.mapper);

            var result = await queryHandler.Handle(query, CancellationToken.None);

            Assert.IsType<List<RestaurantLocationResponse>>(result);
            locationsRepository.VerifyGetAllAsyncForRestaurant(Times.Once());
        }
    }
}
