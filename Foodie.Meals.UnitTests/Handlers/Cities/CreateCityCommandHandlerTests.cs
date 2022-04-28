using AutoMapper;
using Foodie.Meals.Application.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public async void CreateCategoryCommandHandler_HandleCreatingNewCategory_ShouldReturnNewCreatedCategory()
        {
            var categoriesRepository = new MockCategoriesRepository()
                .MockCreateAsync();

            var command = new CreateCategoryCommand { Name = "Test category" };
            var commandHandler = new CreateCategoryCommandHandler(categoriesRepository.Object, this.mapper);

            var result = await commandHandler.Handle(command, CancellationToken.None);

            Assert.IsType<CreateCategoryCommandResponse>(result);
            categoriesRepository.VerifyCreateAsync(Times.Once());
        }
    }
}
