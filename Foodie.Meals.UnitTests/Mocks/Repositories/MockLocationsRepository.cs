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
    public class MockLocationsRepository : Mock<ILocationsRepository>
    {
        public MockLocationsRepository MockCreateAsync()
        {
            Setup(r => r.CreateAsync(It.IsAny<Location>())).ReturnsAsync((Location location) =>
            {
                location.Id = 1;
                return location;
            });

            return this;
        }

        public MockLocationsRepository VerifyCreateAsync(Times times)
        {
            Verify(r => r.CreateAsync(It.IsAny<Location>()), times);

            return this;
        }

        public MockLocationsRepository MockUpdateAsync()
        {
            Setup(r => r.UpdateAsync(It.IsAny<Location>())).Returns(Task.CompletedTask);

            return this;
        }

        public MockLocationsRepository VerifyUpdateAsync(Times times)
        {
            Verify(r => r.UpdateAsync(It.IsAny<Location>()), times);

            return this;
        }

        public MockLocationsRepository MockDeleteAsync()
        {
            Setup(r => r.DeleteAsync(It.IsAny<Location>())).Returns(Task.CompletedTask);

            return this;
        }

        public MockLocationsRepository VerifyDeleteAsync(Times times)
        {
            Verify(r => r.DeleteAsync(It.IsAny<Location>()), times);

            return this;
        }

        public MockLocationsRepository MockGetByIdAsync()
        {
            Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((int locationId) =>
            {
                return new Location
                {
                    Id = locationId,
                    Address = "Test address",
                    Email = "test@email.com",
                    PhoneNumber = "123-456-789",
                    CityId = 1,
                    RestaurantId = 1
                };
            });

            return this;
        }

        public MockLocationsRepository VerifyGetByIdAsync(Times times)
        {
            Verify(r => r.GetByIdAsync(It.IsAny<int>()), times);

            return this;
        }

        public MockLocationsRepository MockGetByIdAsyncWithNullResult()
        {
            Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((int locationId) =>
            {
                return null;
            });

            return this;
        }

        public MockLocationsRepository VerifyGetByIdAsyncWithNullResult(Times times)
        {
            Verify(r => r.GetByIdAsync(It.IsAny<int>()), times);

            return this;
        }

        public MockLocationsRepository MockGetAllAsync()
        {
            var locations = new List<Location>
            {
                new Location
                {
                    Id = 1,
                    Address = "Test address",
                    Email = "test@email.com",
                    PhoneNumber = "123-456-789",
                    CityId = 1,
                    RestaurantId = 1
                },
                new Location
                {
                    Id = 2,
                    Address = "Test address",
                    Email = "test@email.com",
                    PhoneNumber = "123-456-789",
                    CityId = 2,
                    RestaurantId = 2
                },
                new Location
                {
                    Id = 3,
                    Address = "Test address",
                    Email = "test@email.com",
                    PhoneNumber = "123-456-789",
                    CityId = 3,
                    RestaurantId = 3
                }
            };

            Setup(r => r.GetAllAsync()).ReturnsAsync(locations);

            return this;
        }

        public MockLocationsRepository VerifyGetAllAsync(Times times)
        {
            Verify(r => r.GetAllAsync(), times);

            return this;
        }

        public MockLocationsRepository MockGetAllAsyncWithPagingParameters()
        {
            Setup(r => r.GetAllAsync(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int?>(), It.IsAny<int?>())).ReturnsAsync((int pageNumber, int pageSize, int? restaurantId, int? cityId) =>
            {
                var locations = new List<Location>
                {
                    new Location
                {
                    Id = 1,
                    Address = "Test address",
                    Email = "test@email.com",
                    PhoneNumber = "123-456-789",
                    CityId = 1,
                    RestaurantId = 1
                },
                new Location
                {
                    Id = 2,
                    Address = "Test address",
                    Email = "test@email.com",
                    PhoneNumber = "123-456-789",
                    CityId = 2,
                    RestaurantId = 2
                },
                new Location
                {
                    Id = 3,
                    Address = "Test address",
                    Email = "test@email.com",
                    PhoneNumber = "123-456-789",
                    CityId = 3,
                    RestaurantId = 3
                }
                };

                return new PagedList<Location>(locations, locations.Count, pageNumber, pageSize);
            });

            return this;
        }

        public MockLocationsRepository VerifyGetAllAsyncWithPagingParameters(Times times)
        {
            Verify(r => r.GetAllAsync(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int?>(), It.IsAny<int?>()), times);

            return this;
        }

        public MockLocationsRepository MockGetAllAsyncForRestaurant()
        {
            Setup(r => r.GetAllAsync(It.IsAny<int>(), It.IsAny<int?>())).ReturnsAsync((int restaurantId, int? cityId) =>
            {
                var locations = new List<Location>
                {
                    new Location
                    {
                        Id = 1,
                        Address = "Test address",
                        Email = "test@email.com",
                        PhoneNumber = "123-456-789",
                        CityId = 1,
                        RestaurantId = restaurantId
                    },
                    new Location
                    {
                        Id = 2,
                        Address = "Test address",
                        Email = "test@email.com",
                        PhoneNumber = "123-456-789",
                        CityId = 2,
                        RestaurantId = restaurantId
                    },
                    new Location
                    {
                        Id = 3,
                        Address = "Test address",
                        Email = "test@email.com",
                        PhoneNumber = "123-456-789",
                        CityId = 3,
                        RestaurantId = restaurantId
                    }
                };

                return locations;
            });

            return this;
        }

        public MockLocationsRepository VerifyGetAllAsyncForRestaurant(Times times)
        {
            Verify(r => r.GetAllAsync(It.IsAny<int>(), It.IsAny<int?>()), times);

            return this;
        }
    }
}
