using AutoMapper;
using Foodie.Meals.Application.Functions.Meals.Commands.CreateMeal;
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

namespace Foodie.Meals.UnitTests.Handlers.Meals
{
    public class CreateMealCommandHandlerTests
    {
        private readonly IMapper mapper;

        public CreateMealCommandHandlerTests()
        {
            var mapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile<MapperProfile>();
            });

            this.mapper = mapperConfiguration.CreateMapper();
        }

        [Fact]
        public async void CreateMealCommandHandler_HandleCreatingNewMeal_ShouldReturnNewCreatedMeal()
        {
            var mealsRepository = new MockMealsRepository()
                .MockCreateAsync();

            var command = new CreateMealCommand { Name = "Test meal", Description = "Test description", Price = 123, RestaurantId = 1 };
            var commandHandler = new CreateMealCommandHandler(mealsRepository.Object, this.mapper);

            var result = await commandHandler.Handle(command, CancellationToken.None);

            Assert.IsType<CreateMealCommandResponse>(result);
            mealsRepository.VerifyCreateAsync(Times.Once());
        }
    }
}
