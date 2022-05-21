using AutoMapper;
using Foodie.Meals.Application.Functions.Cities.Queries.GetCityById;
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
    public class GetCityByIdQueryHandlerTests
    {
        private readonly IMapper mapper;

        public GetCityByIdQueryHandlerTests()
        {
            var mapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile<MapperProfile>();
            });

            this.mapper = mapperConfiguration.CreateMapper();
        }

        [Fact]
        public async void GetCityByIdQueryHandler_HandleFetchingExistingCity_ShouldSucessfullyFetchExistingCity()
        {
            var citiesRepository = new MockCitiesRepository()
                .MockGetByIdAsync();

            var query = new GetCityByIdQuery(1);

            var queryHandler = new GetCityByIdQueryHandler(citiesRepository.Object, this.mapper);

            var result = await queryHandler.Handle(query, CancellationToken.None);

            Assert.IsType<CityDetailsResponse>(result);
            citiesRepository.VerifyGetByIdAsync(Times.Once());
        }

        [Fact]
        public async void GetCityByIdQueryHandler_HandleFetchingNonExistingCity_ShouldThrowCityNotFoundException()
        {
            var citiesRepository = new MockCitiesRepository()
                .MockGetByIdAsyncWithNullResult();

            var query = new GetCityByIdQuery(1);

            var queryHandler = new GetCityByIdQueryHandler(citiesRepository.Object, this.mapper);

            await Assert.ThrowsAsync<CityNotFoundException>(async () => await queryHandler.Handle(query, CancellationToken.None));
            citiesRepository.VerifyGetByIdAsyncWithNullResult(Times.Once());
        }
    }
}
