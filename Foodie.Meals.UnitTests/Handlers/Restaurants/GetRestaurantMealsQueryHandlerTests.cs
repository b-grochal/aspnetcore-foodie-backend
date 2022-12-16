using AutoMapper;
using Foodie.Meals.Application.Functions.Restaurants.Queries.GetRestaurantMealsById;
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
    public class GetRestaurantMealsQueryHandlerTests
    {
        private readonly IMapper mapper;

        public GetRestaurantMealsQueryHandlerTests()
        {
            var mapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile<MapperProfile>();
            });

            this.mapper = mapperConfiguration.CreateMapper();
        }

        [Fact]
        public async void GetRestaurantMealsQueryHandler_HandleFetchingAllRestaurantMeals_ShouldSucessfullyFetchRestaurantMeals()
        {
            var mealsRepository = new MockMealsRepository()
                .MockGetAllAsyncForRestaurant();

            var query = new GetRestaurantMealsQuery(1);

            var queryHandler = new GetRestaurantMealsQueryHandler(mealsRepository.Object, this.mapper);

            var result = await queryHandler.Handle(query, CancellationToken.None);

            Assert.IsType<List<RestaurantMealDto>>(result);
            mealsRepository.VerifyGetAllAsyncForRestaurant(Times.Once());
        }
    }
}
