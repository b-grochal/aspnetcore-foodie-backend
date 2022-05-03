using AutoMapper;
using Foodie.Meals.Application.Functions.Locations.Queries.GetLocations;
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
    public class GetLocationsQueryHandlerTests
    {
        private readonly IMapper mapper;

        public GetLocationsQueryHandlerTests()
        {
            var mapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile<MapperProfile>();
            });

            this.mapper = mapperConfiguration.CreateMapper();
        }

        [Fact]
        public async void GetLocationsQueryHandler_HandleFetchingAllLocationsWithoutParameters_ShouldSucessfullyFetchLocations()
        {
            var locationsRepository = new MockLocationsRepository()
                .MockGetAllAsyncWithPagingParameters();

            var query = new GetLocationsQuery
            {
                CityId = 1,
                RestaurantId = 1
            };

            var queryHandler = new GetLocationsQueryHandler(locationsRepository.Object, this.mapper);

            var result = await queryHandler.Handle(query, CancellationToken.None);

            Assert.IsType<LocationsListResponse>(result);
            Assert.Equal(query.CityId, result.CityId);
            Assert.Equal(query.RestaurantId, result.RestaurantId);
            Assert.Equal(query.PageSize, result.PageSize);
            locationsRepository.VerifyGetAllAsyncWithPagingParameters(Times.Once());
        }
    }
}
