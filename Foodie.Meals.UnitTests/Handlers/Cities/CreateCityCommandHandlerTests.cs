using AutoMapper;
using Foodie.Meals.Application.Functions.Cities.Commands.CreateCity;
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

namespace Foodie.Meals.UnitTests.Handlers.Cities
{
    public class CreateCityCommandHandlerTests
    {
        private readonly IMapper mapper;

        public CreateCityCommandHandlerTests()
        {
            var mapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile<MapperProfile>();
            });

            this.mapper = mapperConfiguration.CreateMapper();
        }

        [Fact]
        public async void CreateCityCommandHandler_HandleCreatingNewCity_ShouldReturnNewCreatedCity()
        {
            //var citiesRepository = new MockCitiesRepository()
            //    .MockCreateAsync();

            //var command = new CreateCityCommand{ Name = "Test category", Country = "Test country" };
            //var commandHandler = new CreateCityCommandHandler(citiesRepository.Object, this.mapper);

            //var result = await commandHandler.Handle(command, CancellationToken.None);

            //Assert.IsType<CreateCityCommandResponse>(result);
            //citiesRepository.VerifyCreateAsync(Times.Once());
        }
    }
}
