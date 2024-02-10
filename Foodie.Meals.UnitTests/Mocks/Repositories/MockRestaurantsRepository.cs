using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using Foodie.Meals.Domain.Entities;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Foodie.Meals.UnitTests.Mocks.Repositories
{
    public class MockRestaurantsRepository : Mock<IRestaurantsRepository>
    {
        public MockRestaurantsRepository MockCreateAsync()
        {
            Setup(r => r.CreateAsync(It.IsAny<Restaurant>())).ReturnsAsync((Restaurant restaurant) =>
            {
                restaurant.Id = 1;
                return restaurant;
            });

            return this;
        }

        public MockRestaurantsRepository VerifyCreateAsync(Times times)
        {
            Verify(r => r.CreateAsync(It.IsAny<Restaurant>()), times);

            return this;
        }

        public MockRestaurantsRepository MockUpdateAsync()
        {
            Setup(r => r.UpdateAsync(It.IsAny<Restaurant>())).Returns(Task.CompletedTask);

            return this;
        }

        public MockRestaurantsRepository VerifyUpdateAsync(Times times)
        {
            Verify(r => r.UpdateAsync(It.IsAny<Restaurant>()), times);

            return this;
        }

        public MockRestaurantsRepository MockDeleteAsync()
        {
            Setup(r => r.DeleteAsync(It.IsAny<Restaurant>())).Returns(Task.CompletedTask);

            return this;
        }

        public MockRestaurantsRepository VerifyDeleteAsync(Times times)
        {
            Verify(r => r.DeleteAsync(It.IsAny<Restaurant>()), times);

            return this;
        }

        public MockRestaurantsRepository MockGetByIdAsync()
        {
            Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((int restaurantId) =>
            {
                return new Restaurant
                {
                    Id = restaurantId,
                    Name = "Test restaurant",
                    Categories = new List<Category>()
                };
            });

            return this;
        }

        public MockRestaurantsRepository VerifyGetByIdAsync(Times times)
        {
            Verify(r => r.GetByIdAsync(It.IsAny<int>()), times);

            return this;
        }

        public MockRestaurantsRepository MockGetByIdAsyncWithNullResult()
        {
            Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((int reastaurantId) =>
            {
                return null;
            });

            return this;
        }

        public MockRestaurantsRepository VerifyGetByIdAsyncWithNullResult(Times times)
        {
            Verify(r => r.GetByIdAsync(It.IsAny<int>()), times);

            return this;
        }

        public MockRestaurantsRepository MockGetAllAsync()
        {
            var restaurants = new List<Restaurant>
            {
                new Restaurant
                {
                    Id = 1,
                    Name = "Test restaurant 1"
                },
                new Restaurant
                {
                    Id = 2,
                    Name = "Test restaurant 2"
                },
                new Restaurant
                {
                    Id = 3,
                    Name = "Test restaurant 3"
                }
            };

            Setup(r => r.GetAllAsync()).ReturnsAsync(restaurants);

            return this;
        }

        public MockRestaurantsRepository VerifyGetAllAsync(Times times)
        {
            Verify(r => r.GetAllAsync(), times);

            return this;
        }

        public MockRestaurantsRepository MockGetAllAsyncWithPagingParameters()
        {
            //Setup(r => r.GetAllAsync(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int?>(), It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync((int pageNumber, int pageSize, int? categoryId, string name, string cityName) =>
            //{
            //    var restaurants = new List<Restaurant>
            //{
            //    new Restaurant
            //    {
            //        Id = 1,
            //        Name = "Test restaurant 1"
            //    },
            //    new Restaurant
            //    {
            //        Id = 2,
            //        Name = "Test restaurant 2"
            //    },
            //    new Restaurant
            //    {
            //        Id = 3,
            //        Name = "Test restaurant 3"
            //    }
            //};

            //    return new PagedList<Restaurant>(restaurants, restaurants.Count, pageNumber, pageSize);
            //});

            return this;
        }

        public MockRestaurantsRepository VerifyGetAllAsyncWithPagingParameters(Times times)
        {
            Verify(r => r.GetAllAsync(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int?>(), It.IsAny<string>(), It.IsAny<string>()), times);

            return this;
        }
    }
}
