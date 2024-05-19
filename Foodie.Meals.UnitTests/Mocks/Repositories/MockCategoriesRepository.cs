using Foodie.Meals.Application.Contracts.Infrastructure.Database.Repositories;
using Foodie.Meals.Domain.Entities;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Foodie.Meals.UnitTests.Mocks.Repositories
{
    public class MockCategoriesRepository : Mock<ICategoriesRepository>
    {
        public MockCategoriesRepository MockCreateAsync()
        {
            Setup(r => r.CreateAsync(It.IsAny<Category>())).ReturnsAsync((Category category) =>
            {
                category.Id = 1;
                return category;
            });

            return this;
        }

        public MockCategoriesRepository VerifyCreateAsync(Times times)
        {
            Verify(r => r.CreateAsync(It.IsAny<Category>()), times);

            return this;
        }

        public MockCategoriesRepository MockUpdateAsync()
        {
            Setup(r => r.UpdateAsync(It.IsAny<Category>())).Returns(Task.CompletedTask);

            return this;
        }

        public MockCategoriesRepository VerifyUpdateAsync(Times times)
        {
            Verify(r => r.UpdateAsync(It.IsAny<Category>()), times);

            return this;
        }

        public MockCategoriesRepository MockDeleteAsync()
        {
            Setup(r => r.DeleteAsync(It.IsAny<Category>())).Returns(Task.CompletedTask);

            return this;
        }

        public MockCategoriesRepository VerifyDeleteAsync(Times times)
        {
            Verify(r => r.DeleteAsync(It.IsAny<Category>()), times);

            return this;
        }

        public MockCategoriesRepository MockGetByIdAsync()
        {
            Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((int categoryId) =>
            {
                return new Category
                {
                    Id = categoryId,
                    Name = "Test category"
                };
            });

            return this;
        }

        public MockCategoriesRepository VerifyGetByIdAsync(Times times)
        {
            Verify(r => r.GetByIdAsync(It.IsAny<int>()), times);

            return this;
        }

        public MockCategoriesRepository MockGetByIdAsyncWithNullResult()
        {
            Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((int categoryId) =>
            {
                return null;
            });

            return this;
        }

        public MockCategoriesRepository VerifyGetByIdAsyncWithNullResult(Times times)
        {
            Verify(r => r.GetByIdAsync(It.IsAny<int>()), times);

            return this;
        }

        public MockCategoriesRepository MockGetAllAsync()
        {
            var categories = new List<Category>
            {
                new Category
                {
                    Id = 1,
                    Name = "Test category 1"
                },
                new Category
                {
                    Id = 2,
                    Name = "Test category 2"
                },
                new Category
                {
                    Id = 3,
                    Name = "Test category 3"
                }
            };

            Setup(r => r.GetAllAsync()).ReturnsAsync(categories);

            return this;
        }

        public MockCategoriesRepository VerifyGetAllAsync(Times times)
        {
            Verify(r => r.GetAllAsync(), times);

            return this;
        }

        public MockCategoriesRepository MockGetAllAsyncWithPagingParameters()
        {
            //Setup(r => r.GetAllAsync(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).ReturnsAsync((int pageNumber, int pageSize, string name) =>
            //{
            //    var categories = new List<Category>
            //    {
            //        new Category
            //        {
            //            Id = 1,
            //            Name = "Test category 1"
            //        },
            //        new Category
            //        {
            //            Id = 2,
            //            Name = "Test categpry 2"
            //        },
            //        new Category
            //        {
            //            Id = 3,
            //            Name = "Test category 3"
            //        }
            //    };

            //    return new PagedList<Category>(categories, categories.Count, pageNumber, pageSize);
            //});

            return this;
        }

        public MockCategoriesRepository VerifyGetAllAsyncWithPagingParameters(Times times)
        {
            Verify(r => r.GetAllAsync(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()), times);

            return this;
        }

        public MockCategoriesRepository MockGetAllAsyncWithListOfIdsParameter()
        {
            Setup(r => r.GetAllAsync(It.IsAny<IReadOnlyCollection<int>>())).ReturnsAsync((IReadOnlyCollection<int> categoryIds) =>
            {
                var categories = new List<Category>();

                foreach (var categoryId in categoryIds)
                {
                    categories.Add(new Category { Id = categoryId, Name = "Test category" });
                }

                return categories;
            });

            return this;
        }

        public MockCategoriesRepository VerfiryGetAllAsyncWithListOfIdsParameter(Times times)
        {
            Verify(r => r.GetAllAsync(It.IsAny<IReadOnlyCollection<int>>()), times);

            return this;
        }
    }
}
