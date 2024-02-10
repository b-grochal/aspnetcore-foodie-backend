using Foodie.Meals.Application.Functions.Categories.Commands.CreateCategory;
using Foodie.Meals.Application.Functions.Categories.Commands.DeleteCategory;
using Foodie.Meals.Application.Functions.Categories.Commands.UpdateCategory;
using Foodie.Meals.Application.Functions.Categories.Queries.GetCategories;
using Foodie.Meals.Application.Functions.Categories.Queries.GetCategoryById;
using Foodie.Meals.Domain.Entities;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.UnitTests.Mocks.Mediators
{
    public class MockMediatorForCategories : Mock<IMediator>
    {
        public MockMediatorForCategories MockSendingCreateCategoryCommand()
        {
            Setup(m => m.Send(It.IsAny<CreateCategoryCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync((CreateCategoryCommand createCategoryCommand, CancellationToken cancellationToken) =>
            {
                return new CreateCategoryCommandResponse
                {
                    Id = 1,
                    Name = createCategoryCommand.Name,
                };
            });

            return this;
        }

        public MockMediatorForCategories VerifySendingCreateCategoryCommand(Times times)
        {
            Verify(m => m.Send(It.IsAny<CreateCategoryCommand>(), It.IsAny<CancellationToken>()), times);

            return this;
        }

        public MockMediatorForCategories MockSendingUpdateCategoryCommand()
        {
            Setup(m => m.Send(It.IsAny<UpdateCategoryCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync((UpdateCategoryCommand updateCategoryCommand, CancellationToken cancellationToken) =>
            {
                return new UpdateCategoryCommandResponse
                {
                    Id = updateCategoryCommand.Id,
                    Name = updateCategoryCommand.Name,
                };
            });

            return this;
        }

        public MockMediatorForCategories VerifySendingUpdateCategoryCommand(Times times)
        {
            Verify(m => m.Send(It.IsAny<UpdateCategoryCommand>(), It.IsAny<CancellationToken>()), times);

            return this;
        }

        public MockMediatorForCategories MockSendingDeleteCategoryCommand()
        {
            Setup(m => m.Send(It.IsAny<DeleteCategoryCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync((DeleteCategoryCommand deleteCategoryCommand, CancellationToken cancellationToken) =>
            {
                return new DeleteCategoryCommandResponse
                {
                    Id = deleteCategoryCommand.Id,
                };
            });

            return this;
        }

        public MockMediatorForCategories VerifySendingDeleteCategoryCommand(Times times)
        {
            Verify(m => m.Send(It.IsAny<DeleteCategoryCommand>(), It.IsAny<CancellationToken>()), times);

            return this;
        }

        public MockMediatorForCategories MockSendingGetCategoryByIdQuery()
        {
            Setup(m => m.Send(It.IsAny<GetCategoryByIdQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync((GetCategoryByIdQuery getCategoryByIdQuery, CancellationToken cancellationToken) =>
            {
                return new GetCategoryByIdQueryResponse
                {
                    Id = getCategoryByIdQuery.Id,
                    Name = "Test category"
                };
            });

            return this;
        }

        public MockMediatorForCategories VerifySendingGetCategoryByIdQuery(Times times)
        {
            Verify(m => m.Send(It.IsAny<GetCategoryByIdQuery>(), It.IsAny<CancellationToken>()), times);

            return this;
        }

        public MockMediatorForCategories MockSendingGetCategoriesQuery()
        {
            Setup(m => m.Send(It.IsAny<GetCategoriesQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync((GetCategoriesQuery getCategoriesQuery, CancellationToken cancellationToken) =>
            {
                //return new GetCategoriesQueryResponse
                //{
                //    Name = getCategoriesQuery.Name,
                //    PageSize = getCategoriesQuery.PageSize,
                //    Page = getCategoriesQuery.PageNumber,
                //    TotalPages = 2,
                //    Categories = new List<CategoryDto>
                //    {
                //        new CategoryDto
                //        {
                //            Id = 1,
                //            Name = "Test category 1"
                //        },
                //        new CategoryDto
                //        {
                //            Id = 2,
                //            Name = "Test category 2"
                //        },
                //        new CategoryDto
                //        {
                //            Id = 3,
                //            Name = "Test category 3"
                //        }
                //    }
                //};
                return null;
            });

            return this;
        }

        public MockMediatorForCategories VerifySendingGetCategoriesQuery(Times times)
        {
            Verify(m => m.Send(It.IsAny<GetCategoriesQuery>(), It.IsAny<CancellationToken>()), times);

            return this;
        }
    }
}
