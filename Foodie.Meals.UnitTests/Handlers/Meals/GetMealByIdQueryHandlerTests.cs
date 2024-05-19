//using AutoMapper;
//using Foodie.Meals.Application.Functions.Meals.Queries.GetMealById;
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

//namespace Foodie.Meals.UnitTests.Handlers.Meals
//{
//    public class GetMealByIdQueryHandlerTests
//    {
//        private readonly IMapper mapper;

//        public GetMealByIdQueryHandlerTests()
//        {
//            var mapperConfiguration = new MapperConfiguration(c =>
//            {
//                c.AddProfile<MapperProfile>();
//            });

//            this.mapper = mapperConfiguration.CreateMapper();
//        }

//        [Fact]
//        public async void GetMealByIdQueryHandler_HandleFetchingExistingMeal_ShouldSucessfullyFetchExistingMeal()
//        {
//            var mealsRepository = new MockMealsRepository()
//                .MockGetByIdAsync();

//            var query = new GetMealByIdQuery(1);

//            var queryHandler = new GetMealByIdQueryHandler(mealsRepository.Object, this.mapper);

//            var result = await queryHandler.Handle(query, CancellationToken.None);

//            Assert.IsType<GetMealByIdQueryResponse>(result);
//            mealsRepository.VerifyGetByIdAsync(Times.Once());
//        }

//        [Fact]
//        public async void GetMealByIdQueryHandler_HandleFetchingNonExistingMeal_ShouldThrowMealNotFoundException()
//        {
//            var mealsRepository = new MockMealsRepository()
//                .MockGetByIdAsyncWithNullResult();

//            var query = new GetMealByIdQuery(1);

//            var queryHandler = new GetMealByIdQueryHandler(mealsRepository.Object, this.mapper);

//            await Assert.ThrowsAsync<MealNotFoundException>(async () => await queryHandler.Handle(query, CancellationToken.None));
//            mealsRepository.VerifyGetByIdAsyncWithNullResult(Times.Once());
//        }
//    }
//}
