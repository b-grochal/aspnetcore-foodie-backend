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
    public class MockMealsRepository : Mock<IMealsRepository>
    {
        public MockMealsRepository MockCreateAsync()
        {
            Setup(r => r.CreateAsync(It.IsAny<Meal>())).ReturnsAsync((Meal meal) =>
            {
                meal.MealId = 1;
                return meal;
            });

            return this;
        }

        public MockMealsRepository VerifyCreateAsync(Times times)
        {
            Verify(r => r.CreateAsync(It.IsAny<Meal>()), times);

            return this;
        }

        public MockMealsRepository MockUpdateAsync()
        {
            Setup(r => r.UpdateAsync(It.IsAny<Meal>())).Returns(Task.CompletedTask);

            return this;
        }

        public MockMealsRepository VerifyUpdateAsync(Times times)
        {
            Verify(r => r.UpdateAsync(It.IsAny<Meal>()), times);

            return this;
        }

        public MockMealsRepository MockDeleteAsync()
        {
            Setup(r => r.DeleteAsync(It.IsAny<Meal>())).Returns(Task.CompletedTask);

            return this;
        }

        public MockMealsRepository VerifyDeleteAsync(Times times)
        {
            Verify(r => r.DeleteAsync(It.IsAny<Meal>()), times);

            return this;
        }

        public MockMealsRepository MockGetByIdAsync()
        {
            Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((int mealId) =>
            {
                return new Meal
                {
                    MealId = mealId,
                    Name = "Test meal",
                    Description = "Test description",
                    Price = 123,
                    RestaurantId = 1
                };
            });

            return this;
        }

        public MockMealsRepository VerifyGetByIdAsync(Times times)
        {
            Verify(r => r.GetByIdAsync(It.IsAny<int>()), times);

            return this;
        }

        public MockMealsRepository MockGetByIdAsyncWithNullResult()
        {
            Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((int mealId) =>
            {
                return null;
            });

            return this;
        }

        public MockMealsRepository VerifyGetByIdAsyncWithNullResult(Times times)
        {
            Verify(r => r.GetByIdAsync(It.IsAny<int>()), times);

            return this;
        }

        public MockMealsRepository MockGetAllAsync()
        {
            var meals = new List<Meal>
            {
                new Meal
                {
                    MealId = 1,
                    Name = "Test meal 1",
                    Description = "Test description 1",
                    Price = 123,
                    RestaurantId = 1
                },
                new Meal
                {
                    MealId = 2,
                    Name = "Test meal 2",
                    Description = "Test description 2",
                    Price = 123,
                    RestaurantId = 1
                },
                new Meal
                {
                    MealId = 3,
                    Name = "Test meal 3",
                    Description = "Test description 3",
                    Price = 123,
                    RestaurantId = 1
                }
            };

            Setup(r => r.GetAllAsync()).ReturnsAsync(meals);

            return this;
        }

        public MockMealsRepository VerifyGetAllAsync(Times times)
        {
            Verify(r => r.GetAllAsync(), times);

            return this;
        }

        public MockMealsRepository MockGetAllAsyncWithPagingParameters()
        {
            Setup(r => r.GetAllAsync(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int?>(), It.IsAny<string>())).ReturnsAsync((int pageNumber, int pageSize, int? restaurantId, string name) =>
            {
                var meals = new List<Meal>
                {
                    new Meal
                    {
                        MealId = 1,
                        Name = "Test meal 1",
                        Description = "Test description 1",
                        Price = 123,
                        RestaurantId = 1
                    },
                    new Meal
                    {
                        MealId = 2,
                        Name = "Test meal 2",
                        Description = "Test description 2",
                        Price = 123,
                        RestaurantId = 1
                    },
                    new Meal
                    {
                        MealId = 3,
                        Name = "Test meal 3",
                        Description = "Test description 3",
                        Price = 123,
                        RestaurantId = 1
                    }
                };

                return new PagedList<Meal>(meals, meals.Count, pageNumber, pageSize);
            });

            return this;
        }

        public MockMealsRepository VerifyGetAllAsyncWithPagingParameters(Times times)
        {
            Verify(r => r.GetAllAsync(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int?>(), It.IsAny<string>()), times);

            return this;
        }

        public MockMealsRepository MockGetAllAsyncForRestaurant()
        {
            Setup(r => r.GetAllAsync(It.IsAny<int>())).ReturnsAsync((int restaurantId) =>
            {
                var meals = new List<Meal>
                {
                    new Meal
                    {
                        MealId = 1,
                        Name = "Test meal 1",
                        Description = "Test description 1",
                        Price = 123,
                        RestaurantId = restaurantId
                    },
                    new Meal
                    {
                        MealId = 2,
                        Name = "Test meal 2",
                        Description = "Test description 2",
                        Price = 123,
                        RestaurantId = restaurantId
                    },
                    new Meal
                    {
                        MealId = 3,
                        Name = "Test meal 3",
                        Description = "Test description 3",
                        Price = 123,
                        RestaurantId = restaurantId
                    }
                };

                return meals;
            });

            return this;
        }

        public MockMealsRepository VerifyGetAllAsyncForRestaurant(Times times)
        {
            Verify(r => r.GetAllAsync(It.IsAny<int>()), times);

            return this;
        }
    }
}
