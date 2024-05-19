//using AutoMapper;
//using Foodie.Meals.Application.Functions.Restaurants.Commands.CreateRestaurant;
//using Foodie.Meals.Application.Mapper;
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
//    public class CreateRestaurantCommandHandlerTests
//    {
//        private readonly IMapper mapper;

//        public CreateRestaurantCommandHandlerTests()
//        {
//            var mapperConfiguration = new MapperConfiguration(c =>
//            {
//                c.AddProfile<MapperProfile>();
//            });

//            this.mapper = mapperConfiguration.CreateMapper();
//        }

//        [Fact]
//        public async void CreateRestaurantCommandHandler_HandleCreatingNewRestaurant_ShouldReturnNewCreatedRestaurant()
//        {
//            var restaurantsRepository = new MockRestaurantsRepository()
//                .MockCreateAsync();

//            var categoriesRepository = new MockCategoriesRepository()
//                .MockGetAllAsyncWithListOfIdsParameter();

//            var command = new CreateRestaurantCommand { Name = "Test restaurant", CategoriesIds = new List<int> { 1,2,3 } };
//            var commandHandler = new CreateRestaurantCommandHandler(restaurantsRepository.Object, categoriesRepository.Object, this.mapper);

//            var result = await commandHandler.Handle(command, CancellationToken.None);

//            Assert.IsType<CreateRestaurantCommandResponse>(result);
//            restaurantsRepository.VerifyCreateAsync(Times.Once());
//        }
//    }
//}
