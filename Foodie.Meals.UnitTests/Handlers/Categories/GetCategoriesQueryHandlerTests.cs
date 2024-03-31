using AutoMapper;
using Foodie.Meals.Application.Features.Categories.Queries.GetCategories;
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

namespace Foodie.Meals.UnitTests.Handlers.Categories
{
    public class GetCategoriesQueryHandlerTests
    {
        private readonly IMapper mapper;

        public GetCategoriesQueryHandlerTests()
        {
            var mapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile<MapperProfile>();
            });

            this.mapper = mapperConfiguration.CreateMapper();
        }

        [Fact]
        public async void GetCategoriesQueryHandler_HandleFetchingAllCategories_ShouldSucessfullyFetchCategories()
        {
            var categoriesRepository = new MockCategoriesRepository()
                .MockGetAllAsyncWithPagingParameters();

            var query = new GetCategoriesQuery
            {
                Name = "Test name"
            };

            var queryHandler = new GetCategoriesQueryHandler(categoriesRepository.Object, this.mapper);

            var result = await queryHandler.Handle(query, CancellationToken.None);

            Assert.IsType<GetCategoriesQueryResponse>(result);
            Assert.Equal(query.Name, result.Name);
            Assert.Equal(query.PageSize, result.PageSize);
            categoriesRepository.VerifyGetAllAsyncWithPagingParameters(Times.Once());
        }
    }
}
