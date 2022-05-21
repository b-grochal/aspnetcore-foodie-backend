using AutoMapper;
using Foodie.Meals.Application.Functions.Categories.Queries.GetCategoryById;
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
    public class GetCategoryByIdQueryHandlerTests
    {
        private readonly IMapper mapper;

        public GetCategoryByIdQueryHandlerTests()
        {
            var mapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile<MapperProfile>();
            });

            this.mapper = mapperConfiguration.CreateMapper();
        }

        [Fact]
        public async void GetCategoryByIdQueryHandler_HandleFetchingExistingCategory_ShouldSucessfullyFetchExistingCategory()
        {
            var categoriesRepository = new MockCategoriesRepository()
                .MockGetByIdAsync();

            var query = new GetCategoryByIdQuery(1);

            var queryHandler = new GetCategoryByIdQueryHandler(categoriesRepository.Object, this.mapper);

            var result = await queryHandler.Handle(query, CancellationToken.None);

            Assert.IsType<CategoryDetailsResponse>(result);
            categoriesRepository.VerifyGetByIdAsync(Times.Once());
        }

        [Fact]
        public async void GetCategoryByIdQueryHandler_HandleFetchingNonExistingCategory_ShouldThrowCategoryNotFoundException()
        {
            var categoriesRepository = new MockCategoriesRepository()
                .MockGetByIdAsyncWithNullResult();

            var query = new GetCategoryByIdQuery(1);

            var queryHandler = new GetCategoryByIdQueryHandler(categoriesRepository.Object, this.mapper);

            await Assert.ThrowsAsync<CategoryNotFoundException>(async () => await queryHandler.Handle(query, CancellationToken.None));
            categoriesRepository.VerifyGetByIdAsyncWithNullResult(Times.Once());
        }
    }
}
