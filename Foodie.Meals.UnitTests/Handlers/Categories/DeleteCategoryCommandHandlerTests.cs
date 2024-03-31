using AutoMapper;
using Foodie.Meals.Application.Features.Categories.Commands.DeleteCategory;
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
    public class DeleteCategoryCommandHandlerTests
    {
        [Fact]
        public async void DeleteCategoryCommandHandler_HandleDeletingExistingCategory_ShouldSucessfullyDeleteExistingCategory()
        {
            var categoriesRepository = new MockCategoriesRepository()
                .MockDeleteAsync()
                .MockGetByIdAsync();

            var command = new DeleteCategoryCommand(1);
            var commandHandler = new DeleteCategoryCommandHandler(categoriesRepository.Object);

            var result = await commandHandler.Handle(command, CancellationToken.None);

            Assert.IsType<DeleteCategoryCommandResponse>(result);
            Assert.Equal(command.Id, result.Id);
            categoriesRepository.VerifyDeleteAsync(Times.Once());
            categoriesRepository.VerifyGetByIdAsync(Times.Once());
        }

        [Fact]
        public async void DeleteCategoryCommandHandler_HandleDeletingNonExistingCategory_ShouldThrowCategoryNotFoundException()
        {
            var categoriesRepository = new MockCategoriesRepository()
                .MockDeleteAsync()
                .MockGetByIdAsyncWithNullResult();

            var command = new DeleteCategoryCommand(1);
            var commandHandler = new DeleteCategoryCommandHandler(categoriesRepository.Object);

            await Assert.ThrowsAsync<CategoryNotFoundException>(async () => await commandHandler.Handle(command, CancellationToken.None));

            categoriesRepository.VerifyDeleteAsync(Times.Never());
            categoriesRepository.VerifyGetByIdAsyncWithNullResult(Times.Once());
        }
    }
}
