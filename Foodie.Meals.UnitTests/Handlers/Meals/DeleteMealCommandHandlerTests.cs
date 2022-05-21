using Foodie.Meals.Application.Functions.Meals.Commands.DeleteMeal;
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
    public class DeleteMealCommandHandlerTests
    {
        [Fact]
        public async void DeleteMealCommandHandler_HandleDeletingExistingMeal_ShouldSucessfullyDeleteExistingMeal()
        {
            var mealsRepository = new MockMealsRepository()
                .MockDeleteAsync()
                .MockGetByIdAsync();

            var command = new DeleteMealCommand(1);
            var commandHandler = new DeleteMealCommandHandler(mealsRepository.Object);

            var result = await commandHandler.Handle(command, CancellationToken.None);

            Assert.IsType<DeleteMealCommandResponse>(result);
            Assert.Equal(command.MealId, result.MealId);
            mealsRepository.VerifyDeleteAsync(Times.Once());
            mealsRepository.VerifyGetByIdAsync(Times.Once());
        }

        [Fact]
        public async void DeleteMealCommandHandler_HandleDeletingNonExistingMeal_ShouldThrowMealNotFoundException()
        {
            var mealsRepository = new MockMealsRepository()
                .MockDeleteAsync()
                .MockGetByIdAsyncWithNullResult();

            var command = new DeleteMealCommand(1);
            var commandHandler = new DeleteMealCommandHandler(mealsRepository.Object);

            await Assert.ThrowsAsync<MealNotFoundException>(async () => await commandHandler.Handle(command, CancellationToken.None));

            mealsRepository.VerifyDeleteAsync(Times.Never());
            mealsRepository.VerifyGetByIdAsyncWithNullResult(Times.Once());
        }
    }
}
