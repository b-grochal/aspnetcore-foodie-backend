﻿using Foodie.Meals.Application.Functions.Cities.Commands.DeleteCity;
using Foodie.Meals.UnitTests.Mocks.Repositories;
using Moq;
using System.Threading;
using Xunit;

namespace Foodie.Meals.UnitTests.Handlers.Cities
{
    public class DeleteCityCommandHandlerTests
    {
        [Fact]
        public async void DeleteCityCommandHandler_HandleDeletingExistingCity_ShouldSucessfullyDeleteExistingCity()
        {
            //var citiesRepository = new MockCitiesRepository()
            //    .MockDeleteAsync()
            //    .MockGetByIdAsync();

            //var command = new DeleteCityCommand(1);
            //var commandHandler = new DeleteCityCommandHandler(citiesRepository.Object);

            //var result = await commandHandler.Handle(command, CancellationToken.None);

            //Assert.IsType<DeleteCityCommandResponse>(result);
            //Assert.Equal(command.Id, result.Id);
            //citiesRepository.VerifyDeleteAsync(Times.Once());
            //citiesRepository.VerifyGetByIdAsync(Times.Once());
        }

        [Fact]
        public async void DeleteCityCommandHandler_HandleDeletingNonExistingCity_ShouldThrowCityNotFoundException()
        {
            //var cities = new MockCitiesRepository()
            //    .MockDeleteAsync()
            //    .MockGetByIdAsyncWithNullResult();

            //var command = new DeleteCityCommand(1);
            //var commandHandler = new DeleteCityCommandHandler(cities.Object);

            //await Assert.ThrowsAsync<CityNotFoundException>(async () => await commandHandler.Handle(command, CancellationToken.None));

            //cities.VerifyDeleteAsync(Times.Never());
            //cities.VerifyGetByIdAsyncWithNullResult(Times.Once());
        }
    }
}
