//using AutoMapper;
//using Foodie.Meals.Application.Functions.Locations.Queries.GetLocationById;
//using Foodie.Meals.Application.Mapper;
//using Foodie.Meals.Domain.Exceptions;
//using Foodie.Meals.UnitTests.Mocks.Repositories;
//using Moq;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
//using Xunit;

//namespace Foodie.Meals.UnitTests.Handlers.Locations
//{
//    public class GetLocationByIdQueryHandlerTests
//    {
//        private readonly IMapper mapper;

//        public GetLocationByIdQueryHandlerTests()
//        {
//            var mapperConfiguration = new MapperConfiguration(c =>
//            {
//                c.AddProfile<MapperProfile>();
//            });

//            this.mapper = mapperConfiguration.CreateMapper();
//        }

//        [Fact]
//        public async void GetLocationByIdQueryHandler_HandleFetchingExistingLocation_ShouldSucessfullyFetchExistingLocation()
//        {
//            var locationsRepository = new MockLocationsRepository()
//                .MockGetByIdAsync();

//            var query = new GetLocationByIdQuery(1);

//            var queryHandler = new GetLocationByIdQueryHandler(locationsRepository.Object, this.mapper);

//            var result = await queryHandler.Handle(query, CancellationToken.None);

//            Assert.IsType<GetLocationByIdQueryResponse>(result);
//            locationsRepository.VerifyGetByIdAsync(Times.Once());
//        }

//        [Fact]
//        public async void GetLocationByIdQueryHandler_HandleFetchingNonExistingLocation_ShouldThrowLocationNotFoundException()
//        {
//            var locationsRepository = new MockLocationsRepository()
//                .MockGetByIdAsyncWithNullResult();

//            var query = new GetLocationByIdQuery(1);

//            var queryHandler = new GetLocationByIdQueryHandler(locationsRepository.Object, this.mapper);

//            await Assert.ThrowsAsync<LocationNotFoundException>(async () => await queryHandler.Handle(query, CancellationToken.None));
//            locationsRepository.VerifyGetByIdAsyncWithNullResult(Times.Once());
//        }
//    }
//}
