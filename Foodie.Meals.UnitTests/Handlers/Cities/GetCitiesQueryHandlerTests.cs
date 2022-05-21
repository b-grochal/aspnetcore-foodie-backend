using AutoMapper;
using Foodie.Meals.Application.Functions.Cities.Queries.GetCities;
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
    public class GetCitiesQueryHandlerTests
    {
        private readonly IMapper mapper;

        public GetCitiesQueryHandlerTests()
        {
            var mapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile<MapperProfile>();
            });

            this.mapper = mapperConfiguration.CreateMapper();
        }

        [Fact]
        public async void GetCitiesQueryHandler_HandleFetchingAllCities_ShouldSucessfullyFetchCities()
        {
            var citiesRepository = new MockCitiesRepository()
                .MockGetAllAsyncWithPagingParameters();

            var query = new GetCitiesQuery
            {
                Name = "Test name",
                Country = "Test country"
            };

            var queryHandler = new GetCitiesQueryHandler(citiesRepository.Object, this.mapper);

            var result = await queryHandler.Handle(query, CancellationToken.None);

            Assert.IsType<CitiesListResponse>(result);
            Assert.Equal(query.Name, result.Name);
            Assert.Equal(query.Country, result.Country);
            Assert.Equal(query.PageSize, result.PageSize);
            citiesRepository.VerifyGetAllAsyncWithPagingParameters(Times.Once());
        }
    }
}
