using AutoMapper;
using Foodie.Meals.Application.Functions.Restaurants.Queries.GetRestaurants;
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
    public class GetRestaurantsQueryHandlerTests
    {
        private readonly IMapper mapper;

        public GetRestaurantsQueryHandlerTests()
        {
            var mapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile<MapperProfile>();
            });

            this.mapper = mapperConfiguration.CreateMapper();
        }

        [Fact]
        public async void GetRestaurantsQueryHandler_HandleFetchingAllRestaurants_ShouldSucessfullyFetchRestaurants()
        {
            var restaurantsRepository = new MockRestaurantsRepository()
                .MockGetAllAsyncWithPagingParameters();

            var query = new GetRestaurantsQuery
            {
                CategoryId = 1,
                Name = "Test name",
                CityName = "Test city name"
            };

            var queryHandler = new GetRestaurantsQueryHandler(restaurantsRepository.Object, this.mapper);

            var result = await queryHandler.Handle(query, CancellationToken.None);

            Assert.IsType<GetRestaurantsQueryResponse>(result);
            Assert.Equal(query.CategoryId, result.CategoryId);
            Assert.Equal(query.Name, result.Name);
            Assert.Equal(query.CityName, result.CityName);
            restaurantsRepository.VerifyGetAllAsyncWithPagingParameters(Times.Once());
        }
    }
}
