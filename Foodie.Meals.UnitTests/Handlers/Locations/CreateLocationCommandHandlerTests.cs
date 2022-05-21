using AutoMapper;
using Foodie.Meals.Application.Functions.Locations.Commands.CreateLocation;
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

namespace Foodie.Meals.UnitTests.Handlers.Locations
{
    public class CreateLocationCommandHandlerTests
    {
        private readonly IMapper mapper;

        public CreateLocationCommandHandlerTests()
        {
            var mapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile<MapperProfile>();
            });

            this.mapper = mapperConfiguration.CreateMapper();
        }

        [Fact]
        public async void CreateLocationCommandHandler_HandleCreatingNewLocation_ShouldReturnNewCreatedLocation()
        {
            var citiesRepository = new MockLocationsRepository()
                .MockCreateAsync();

            var command = new CreateLocationCommand { Address = "Test address", PhoneNumber= "123-456-789", Email = "test@email.com", CityId = 1, RestaurantId = 1 };
            var commandHandler = new CreateLocationCommandHandler(citiesRepository.Object, this.mapper);

            var result = await commandHandler.Handle(command, CancellationToken.None);

            Assert.IsType<CreateLocationCommandResponse>(result);
            citiesRepository.VerifyCreateAsync(Times.Once());
        }
    }
}
