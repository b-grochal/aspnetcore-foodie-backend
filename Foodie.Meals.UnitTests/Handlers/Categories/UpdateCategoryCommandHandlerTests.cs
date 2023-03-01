using AutoMapper;
using Foodie.Meals.Application.Functions.Categories.Commands.UpdateCategory;
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

namespace Foodie.Meals.UnitTests.Handlers.Categories
{
    public class UpdateCategoryCommandHandlerTests
    {
        private readonly IMapper mapper;

        public UpdateCategoryCommandHandlerTests()
        {
            var mapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile<MapperProfile>();
            });

            this.mapper = mapperConfiguration.CreateMapper();
        }

        [Fact]
        public async void UpdateCategoryCommandHandler_HandleUpdatingExistingCategory_ShouldSucessfullyUpdateExistingCategory()
        {
            var categoriesRepository = new MockCategoriesRepository()
                .MockUpdateAsync()
                .MockGetByIdAsync();

            var command = new UpdateCategoryCommand 
            { 
                CategoryId = 1,
                Name = "Test category" 
            };

            var commandHandler = new UpdateCategoryCommandHandler(categoriesRepository.Object, this.mapper);

            var result = await commandHandler.Handle(command, CancellationToken.None);

            Assert.IsType<UpdateCategoryCommandResponse>(result);
            Assert.Equal(command.CategoryId, result.Id);
            Assert.Equal(command.Name, result.Name);
            categoriesRepository.VerifyUpdateAsync(Times.Once());
            categoriesRepository.VerifyGetByIdAsync(Times.Once());
        }

        [Fact]
        public async void UpdateCategoryCommandHandler_HandleUpdatingNonExistingCategory_ShouldThrowCategoryNotFoundException()
        {
            var categoriesRepository = new MockCategoriesRepository()
                .MockUpdateAsync()
                .MockGetByIdAsyncWithNullResult();

            var command = new UpdateCategoryCommand
            {
                CategoryId = 1,
                Name = "Test category"
            };

            var commandHandler = new UpdateCategoryCommandHandler(categoriesRepository.Object, this.mapper);

            await Assert.ThrowsAsync<CategoryNotFoundException>(async () => await commandHandler.Handle(command, CancellationToken.None));

            categoriesRepository.VerifyUpdateAsync(Times.Never());
            categoriesRepository.VerifyGetByIdAsyncWithNullResult(Times.Once());
        }
    }
}
