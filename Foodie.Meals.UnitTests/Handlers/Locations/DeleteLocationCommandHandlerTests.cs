using Foodie.Meals.Application.Functions.Locations.Commands.DeleteLocation;
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

namespace Foodie.Meals.UnitTests.Handlers.Locations
{
    public class DeleteLocationCommandHandlerTests
    {
        [Fact]
        public async void DeleteLocationCommandHandler_HandleDeletingExistingLocation_ShouldSucessfullyDeleteExistingLocation()
        {
            var locationsRepository = new MockLocationsRepository()
                .MockDeleteAsync()
                .MockGetByIdAsync();

            var command = new DeleteLocationCommand(1);
            var commandHandler = new DeleteLocationCommandHandler(locationsRepository.Object);

            var result = await commandHandler.Handle(command, CancellationToken.None);

            Assert.IsType<DeleteLocationCommandResponse>(result);
            Assert.Equal(command.LocationId, result.LocationId);
            locationsRepository.VerifyDeleteAsync(Times.Once());
            locationsRepository.VerifyGetByIdAsync(Times.Once());
        }

        [Fact]
        public async void DeleteCityCommandHandler_HandleDeletingNonExistingCity_ShouldThrowCityNotFoundException()
        {
            var locationsRepository = new MockLocationsRepository()
                .MockDeleteAsync()
                .MockGetByIdAsyncWithNullResult();

            var command = new DeleteLocationCommand(1);
            var commandHandler = new DeleteLocationCommandHandler(locationsRepository.Object);

            await Assert.ThrowsAsync<LocationNotFoundException>(async () => await commandHandler.Handle(command, CancellationToken.None));

            locationsRepository.VerifyDeleteAsync(Times.Never());
            locationsRepository.VerifyGetByIdAsyncWithNullResult(Times.Once());
        }
    }
}
