using AutoMapper;
using Foodie.Meals.Application.Functions.Meals.Commands.UpdateMeal;
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

namespace Foodie.Meals.UnitTests.Handlers.Meals
{
    public class UpdateMealCommandHandlerTests
    {
        private readonly IMapper mapper;

        public UpdateMealCommandHandlerTests()
        {
            var mapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile<MapperProfile>();
            });

            this.mapper = mapperConfiguration.CreateMapper();
        }

        [Fact]
        public async void UpdateMealCommandHandler_HandleUpdatingExistingMeal_ShouldSucessfullyUpdateExistingMeal()
        {
            var mealsRepository = new MockMealsRepository()
                .MockUpdateAsync()
                .MockGetByIdAsync();

            var command = new UpdateMealCommand
            {
                Id = 1,
                Name = "Test name",
                Description= "Test description",
                Price = 123,
                RestaurantId = 1
            };

            var commandHandler = new UpdateMealCommandHandler(mealsRepository.Object, this.mapper);

            var result = await commandHandler.Handle(command, CancellationToken.None);

            Assert.IsType<UpdateMealCommandResponse>(result);
            Assert.Equal(command.Id, result.Id);
            Assert.Equal(command.Name, result.Name);
            Assert.Equal(command.Description, result.Description);
            Assert.Equal(command.Price, result.Price);
            Assert.Equal(command.RestaurantId, result.RestaurantId);
            mealsRepository.VerifyUpdateAsync(Times.Once());
            mealsRepository.VerifyGetByIdAsync(Times.Once());
        }

        [Fact]
        public async void UpdateMealCommandHandler_HandleUpdatingNonExistingMeal_ShouldThrowMealNotFoundException()
        {
            var mealsRepository = new MockMealsRepository()
                .MockUpdateAsync()
                .MockGetByIdAsyncWithNullResult();

            var command = new UpdateMealCommand
            {
                Id = 1,
                Name = "Test name",
                Description = "Test description",
                Price = 123,
                RestaurantId = 1
            };

            var commandHandler = new UpdateMealCommandHandler(mealsRepository.Object, this.mapper);

            await Assert.ThrowsAsync<MealNotFoundException>(async () => await commandHandler.Handle(command, CancellationToken.None));

            mealsRepository.VerifyUpdateAsync(Times.Never());
            mealsRepository.VerifyGetByIdAsyncWithNullResult(Times.Once());
        }
    }
}
