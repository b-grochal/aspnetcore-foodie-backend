//using AutoMapper;
//using Foodie.Meals.Application.Functions.Restaurants.Queries.GetRestaurantById;
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

//namespace Foodie.Meals.UnitTests.Handlers.Restaurants
//{
//    public class GetRestaurantByIdQueryHandlerTests
//    {
//        private readonly IMapper mapper;

//        public GetRestaurantByIdQueryHandlerTests()
//        {
//            var mapperConfiguration = new MapperConfiguration(c =>
//            {
//                c.AddProfile<MapperProfile>();
//            });

//            this.mapper = mapperConfiguration.CreateMapper();
//        }

//        [Fact]
//        public async void GetRestaurantByIdQueryHandler_HandleFetchingExistingRestaurant_ShouldSucessfullyFetchExistingRestaurant()
//        {
//            var restaurantsRepository = new MockRestaurantsRepository()
//                .MockGetByIdAsync();

//            var query = new GetRestaurantByIdQuery(1);

//            var queryHandler = new GetRestaurantByIdQueryHandler(restaurantsRepository.Object, this.mapper);

//            var result = await queryHandler.Handle(query, CancellationToken.None);

//            Assert.IsType<GetRestaurantByIdQueryResponse>(result);
//            restaurantsRepository.VerifyGetByIdAsync(Times.Once());
//        }

//        [Fact]
//        public async void GetRestaurantByIdQueryHandler_HandleFetchingNonExistingRestaurant_ShouldThrowRestaurantNotFoundException()
//        {
//            var restaurantsRepository = new MockRestaurantsRepository()
//                .MockGetByIdAsyncWithNullResult();

//            var query = new GetRestaurantByIdQuery(1);

//            var queryHandler = new GetRestaurantByIdQueryHandler(restaurantsRepository.Object, this.mapper);

//            await Assert.ThrowsAsync<RestaurantNotFoundException>(async () => await queryHandler.Handle(query, CancellationToken.None));
//            restaurantsRepository.VerifyGetByIdAsyncWithNullResult(Times.Once());
//        }
//    }
//}
