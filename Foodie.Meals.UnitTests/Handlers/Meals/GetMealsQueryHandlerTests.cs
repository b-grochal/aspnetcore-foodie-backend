using AutoMapper;
using Foodie.Meals.Application.Functions.Meals.Queries.GetMeals;
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

namespace Foodie.Meals.UnitTests.Handlers.Meals
{
    public class GetMealsQueryHandlerTests
    {
        private readonly IMapper mapper;

        public GetMealsQueryHandlerTests()
        {
            var mapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile<MapperProfile>();
            });

            this.mapper = mapperConfiguration.CreateMapper();
        }

        [Fact]
        public async void GetMealsQueryHandler_HandleFetchingAllMeals_ShouldSucessfullyFetchMeals()
        {
            var mealsRepository = new MockMealsRepository()
                .MockGetAllAsyncWithPagingParameters();

            var query = new GetMealsQuery
            {
                Name = "Test name",
                RestaurantId = 1
            };

            var queryHandler = new GetMealsQueryHandler(mealsRepository.Object, this.mapper);

            var result = await queryHandler.Handle(query, CancellationToken.None);

            Assert.IsType<MealsListResponse>(result);
            Assert.Equal(query.Name, result.Name);
            Assert.Equal(query.RestaurantId, result.RestaurantId);
            Assert.Equal(query.PageSize, result.PageSize);
            mealsRepository.VerifyGetAllAsyncWithPagingParameters(Times.Once());
        }
    }
}
