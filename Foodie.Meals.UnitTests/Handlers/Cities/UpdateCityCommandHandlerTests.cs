using AutoMapper;
using Foodie.Meals.Application.Functions.Cities.Commands.UpdateCity;
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

namespace Foodie.Meals.UnitTests.Handlers.Cities
{
    public class UpdateCityCommandHandlerTests
    {
        private readonly IMapper mapper;

        public UpdateCityCommandHandlerTests()
        {
            var mapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile<MapperProfile>();
            });

            this.mapper = mapperConfiguration.CreateMapper();
        }

        [Fact]
        public async void UpdateCityCommandHandler_HandleUpdatingExistingCity_ShouldSucessfullyUpdateExistingCity()
        {
            var citiesRepository = new MockCitiesRepository()
                .MockUpdateAsync()
                .MockGetByIdAsync();

            var command = new UpdateCityCommand
            {
                CityId = 1,
                Name = "Test category",
                Country = "Test country"
            };

            var commandHandler = new UpdateCityCommandHandler(citiesRepository.Object, this.mapper);

            var result = await commandHandler.Handle(command, CancellationToken.None);

            Assert.IsType<UpdateCityCommandResponse>(result);
            Assert.Equal(command.CityId, result.Id);
            Assert.Equal(command.Name, result.Name);
            Assert.Equal(command.Country, result.Country);
            citiesRepository.VerifyUpdateAsync(Times.Once());
            citiesRepository.VerifyGetByIdAsync(Times.Once());
        }

        [Fact]
        public async void UpdateCityCommandHandler_HandleUpdatingNonExistingCity_ShouldThrowCityNotFoundException()
        {
            var citiesRepository = new MockCitiesRepository()
                .MockUpdateAsync()
                .MockGetByIdAsyncWithNullResult();

            var command = new UpdateCityCommand
            {
                CityId = 1,
                Name = "Test category",
                Country = "Test country"
            };

            var commandHandler = new UpdateCityCommandHandler(citiesRepository.Object, this.mapper);

            await Assert.ThrowsAsync<CityNotFoundException>(async () => await commandHandler.Handle(command, CancellationToken.None));

            citiesRepository.VerifyUpdateAsync(Times.Never());
            citiesRepository.VerifyGetByIdAsyncWithNullResult(Times.Once());
        }
    }
}
