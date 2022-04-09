using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using Foodie.Meals.Domain.Entities;
using Foodie.Shared.Extensions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.UnitTests.Mocks.Repositories
{
    public class MockCategoriesRepository : Mock<ICategoriesRepository>
    {
        public MockCategoriesRepository MockCreateAsync()
        {
            Setup(r => r.CreateAsync(It.IsAny<Category>())).ReturnsAsync((Category category) =>
            {
                category.CategoryId = 1;
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
                    CategoryId = categoryId,
                    Name = "Pizza"
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
                    CategoryId = 1,
                    Name = "Test category"
                },
                new Category
                {
                    CategoryId= 2,
                    Name = "Test category"
                },
                new Category
                {
                    CategoryId = 3,
                    Name = "Test category"
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
            Setup(r => r.GetAllAsync(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).ReturnsAsync((int pageNumber, int pageSize, string name) =>
            {
                var categories = new List<Category>
                {
                    new Category
                    {
                        CategoryId = 1,
                        Name = "Pizza"
                    },
                    new Category
                    {
                        CategoryId= 2,
                        Name = "Kebab"
                    },
                    new Category
                    {
                        CategoryId = 3,
                        Name = "Burger"
                    }
                };

                return new PagedList<Category>(categories, categories.Count, pageNumber, pageSize);
            });

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
                    categories.Add(new Category { CategoryId = categoryId, Name = "Test Category" });
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
