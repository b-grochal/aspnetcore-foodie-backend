using Foodie.Meals.Application.Functions.Restaurants.Commands.DeleteRestaurant;
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
    public class DeleteRestaurantCommandHandlerTests
    {
        [Fact]
        public async void DeleteRestaurantCommandHandler_HandleDeletingExistingRestaurant_ShouldSucessfullyDeleteExistingRestaurant()
        {
            var restaurantsRepository = new MockRestaurantsRepository()
                .MockDeleteAsync()
                .MockGetByIdAsync();

            var command = new DeleteRestaurantCommand(1);
            var commandHandler = new DeleteRestaurantCommandHandler(restaurantsRepository.Object);

            var result = await commandHandler.Handle(command, CancellationToken.None);

            Assert.IsType<DeleteRestaurantCommandResponse>(result);
            Assert.Equal(command.Id, result.Id);
            restaurantsRepository.VerifyDeleteAsync(Times.Once());
            restaurantsRepository.VerifyGetByIdAsync(Times.Once());
        }

        [Fact]
        public async void DeleteRestaurantCommandHandler_HandleDeletingNonExistingRestaurant_ShouldThrowRestaurantNotFoundException()
        {
            var restaurantsRepository = new MockRestaurantsRepository()
                .MockDeleteAsync()
                .MockGetByIdAsyncWithNullResult();

            var command = new DeleteRestaurantCommand(1);
            var commandHandler = new DeleteRestaurantCommandHandler(restaurantsRepository.Object);

            await Assert.ThrowsAsync<RestaurantNotFoundException>(async () => await commandHandler.Handle(command, CancellationToken.None));

            restaurantsRepository.VerifyDeleteAsync(Times.Never());
            restaurantsRepository.VerifyGetByIdAsyncWithNullResult(Times.Once());
        }
    }
}
