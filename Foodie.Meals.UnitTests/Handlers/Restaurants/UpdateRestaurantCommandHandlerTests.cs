using AutoMapper;
using Foodie.Meals.Application.Functions.Restaurants.Commands.UpdateRestaurant;
using Foodie.Meals.Application.Mapper;
using Foodie.Meals.Domain.Exceptions;
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
    public class UpdateRestaurantCommandHandlerTests
    {
        private readonly IMapper mapper;

        public UpdateRestaurantCommandHandlerTests()
        {
            var mapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile<MapperProfile>();
            });

            this.mapper = mapperConfiguration.CreateMapper();
        }

        [Fact]
        public async void UpdateRestaurantCommandHandler_HandleUpdatingExistingRestaurant_ShouldSucessfullyUpdateExistingRestaurant()
        {
            var restaurantsRepository = new MockRestaurantsRepository()
                .MockUpdateAsync()
                .MockGetByIdAsync();

            var categoriesRepository = new MockCategoriesRepository()
                .MockGetAllAsyncWithListOfIdsParameter();

            var command = new UpdateRestaurantCommand
            {
                Id = 1,
                Name = "Test name",
                CategoryIds = new List<int> { 1, 2, 3 }
            };

            var commandHandler = new UpdateRestaurantCommandHandler(restaurantsRepository.Object, categoriesRepository.Object, this.mapper);

            var result = await commandHandler.Handle(command, CancellationToken.None);

            Assert.IsType<UpdateRestaurantCommandResponse>(result);
            Assert.Equal(command.Id, result.Id);
            Assert.Equal(command.Name, result.Name);
            restaurantsRepository.VerifyUpdateAsync(Times.Once());
            restaurantsRepository.VerifyGetByIdAsync(Times.Once());
        }

        [Fact]
        public async void UpdateMealCommandHandler_HandleUpdatingNonExistingMeal_ShouldThrowMealNotFoundException()
        {
            var restaurantsRepository = new MockRestaurantsRepository()
                .MockUpdateAsync()
                .MockGetByIdAsyncWithNullResult();

            var categoriesRepository = new MockCategoriesRepository()
                .MockGetAllAsyncWithListOfIdsParameter();

            var command = new UpdateRestaurantCommand
            {
                Id = 1,
                Name = "Test name",
                CategoryIds = new List<int> { 1, 2, 3 }
            };

            var commandHandler = new UpdateRestaurantCommandHandler(restaurantsRepository.Object, categoriesRepository.Object, this.mapper);

            await Assert.ThrowsAsync<RestaurantNotFoundException>(async () => await commandHandler.Handle(command, CancellationToken.None));

            restaurantsRepository.VerifyUpdateAsync(Times.Never());
            restaurantsRepository.VerifyGetByIdAsyncWithNullResult(Times.Once());
        }
    }
}
