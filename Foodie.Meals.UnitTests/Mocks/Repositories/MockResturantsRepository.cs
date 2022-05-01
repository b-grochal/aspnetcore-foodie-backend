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
    public class MockResturantsRepository : Mock<IRestaurantsRepository>
    {
        public MockResturantsRepository MockCreateAsync()
        {
            Setup(r => r.CreateAsync(It.IsAny<Restaurant>())).ReturnsAsync((Restaurant restaurant) =>
            {
                restaurant.RestaurantId = 1;
                return restaurant;
            });

            return this;
        }

        public MockResturantsRepository VerifyCreateAsync(Times times)
        {
            Verify(r => r.CreateAsync(It.IsAny<Restaurant>()), times);

            return this;
        }

        public MockResturantsRepository MockUpdateAsync()
        {
            Setup(r => r.UpdateAsync(It.IsAny<Restaurant>())).Returns(Task.CompletedTask);

            return this;
        }

        public MockResturantsRepository VerifyUpdateAsync(Times times)
        {
            Verify(r => r.UpdateAsync(It.IsAny<Restaurant>()), times);

            return this;
        }

        public MockResturantsRepository MockDeleteAsync()
        {
            Setup(r => r.DeleteAsync(It.IsAny<Restaurant>())).Returns(Task.CompletedTask);

            return this;
        }

        public MockResturantsRepository VerifyDeleteAsync(Times times)
        {
            Verify(r => r.DeleteAsync(It.IsAny<Restaurant>()), times);

            return this;
        }

        public MockResturantsRepository MockGetByIdAsync()
        {
            Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((int restaurantId) =>
            {
                return new Restaurant
                {
                    RestaurantId = restaurantId,
                    Name = "Test restaurant" 
                };
            });

            return this;
        }

        public MockResturantsRepository VerifyGetByIdAsync(Times times)
        {
            Verify(r => r.GetByIdAsync(It.IsAny<int>()), times);

            return this;
        }

        public MockResturantsRepository MockGetByIdAsyncWithNullResult()
        {
            Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((int reastaurantId) =>
            {
                return null;
            });

            return this;
        }

        public MockResturantsRepository VerifyGetByIdAsyncWithNullResult(Times times)
        {
            Verify(r => r.GetByIdAsync(It.IsAny<int>()), times);

            return this;
        }

        public MockResturantsRepository MockGetAllAsync()
        {
            var restaurants = new List<Restaurant>
            {
                new Restaurant
                {
                    RestaurantId = 1,
                    Name = "Test restaurant 1"
                },
                new Restaurant
                {
                    RestaurantId = 2,
                    Name = "Test restaurant 2"
                },
                new Restaurant
                {
                    RestaurantId = 3,
                    Name = "Test restaurant 3"
                }
            };

            Setup(r => r.GetAllAsync()).ReturnsAsync(restaurants);

            return this;
        }

        public MockResturantsRepository VerifyGetAllAsync(Times times)
        {
            Verify(r => r.GetAllAsync(), times);

            return this;
        }

        public MockResturantsRepository MockGetAllAsyncWithPagingParameters()
        {
            Setup(r => r.GetAllAsync(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int?>(), It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync((int pageNumber, int pageSize, int? categoryId, string name, string cityName) =>
            {
                var restaurants = new List<Restaurant>
            {
                new Restaurant
                {
                    RestaurantId = 1,
                    Name = "Test restaurant 1"
                },
                new Restaurant
                {
                    RestaurantId = 2,
                    Name = "Test restaurant 2"
                },
                new Restaurant
                {
                    RestaurantId = 3,
                    Name = "Test restaurant 3"
                }
            };

                return new PagedList<Restaurant>(restaurants, restaurants.Count, pageNumber, pageSize);
            });

            return this;
        }

        public MockResturantsRepository VerifyGetAllAsyncWithPagingParameters(Times times)
        {
            Verify(r => r.GetAllAsync(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int?>(), It.IsAny<string>(), It.IsAny<string>()), times);

            return this;
        }
    }
}
