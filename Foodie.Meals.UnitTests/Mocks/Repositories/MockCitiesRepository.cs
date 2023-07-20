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
    public class MockCitiesRepository : Mock<ICitiesRepository>
    {
        public MockCitiesRepository MockCreateAsync()
        {
            Setup(r => r.CreateAsync(It.IsAny<City>())).ReturnsAsync((City city) =>
            {
                city.Id= 1;
                return city;
            });

            return this;
        }

        public MockCitiesRepository VerifyCreateAsync(Times times)
        {
            Verify(r => r.CreateAsync(It.IsAny<City>()), times);

            return this;
        }

        public MockCitiesRepository MockUpdateAsync()
        {
            Setup(r => r.UpdateAsync(It.IsAny<City>())).Returns(Task.CompletedTask);

            return this;
        }

        public MockCitiesRepository VerifyUpdateAsync(Times times)
        {
            Verify(r => r.UpdateAsync(It.IsAny<City>()), times);

            return this;
        }

        public MockCitiesRepository MockDeleteAsync()
        {
            Setup(r => r.DeleteAsync(It.IsAny<City>())).Returns(Task.CompletedTask);

            return this;
        }

        public MockCitiesRepository VerifyDeleteAsync(Times times)
        {
            Verify(r => r.DeleteAsync(It.IsAny<City>()), times);

            return this;
        }

        public MockCitiesRepository MockGetByIdAsync()
        {
            //Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((int cityId) =>
            //{
            //    return new City
            //    {
            //        Id = cityId,
            //        Name = "Test city",
            //        Country = "Test country"
            //    };
            //});

            return this;
        }

        public MockCitiesRepository VerifyGetByIdAsync(Times times)
        {
            Verify(r => r.GetByIdAsync(It.IsAny<int>()), times);

            return this;
        }

        public MockCitiesRepository MockGetByIdAsyncWithNullResult()
        {
            Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((int cityId) =>
            {
                return null;
            });

            return this;
        }

        public MockCitiesRepository VerifyGetByIdAsyncWithNullResult(Times times)
        {
            Verify(r => r.GetByIdAsync(It.IsAny<int>()), times);

            return this;
        }

        public MockCitiesRepository MockGetAllAsync()
        {
            //var categories = new List<City>
            //{
            //    new City
            //    {
            //        Id = 1,
            //        Name = "Test category 1",
            //        Country = "Test country 1"
            //    },
            //    new City
            //    {
            //        Id= 2,
            //        Name = "Test category 2",
            //        Country = "Test country 2"
            //    },
            //    new City
            //    {
            //        Id = 3,
            //        Name = "Test category 3",
            //        Country = "Test country 3"
            //    }
            //};

            //Setup(r => r.GetAllAsync()).ReturnsAsync(categories);

            return this;
        }

        public MockCitiesRepository VerifyGetAllAsync(Times times)
        {
            Verify(r => r.GetAllAsync(), times);

            return this;
        }

        public MockCitiesRepository MockGetAllAsyncWithPagingParameters()
        {
            //Setup(r => r.GetAllAsync(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync((int pageNumber, int pageSize, string name, string country) =>
            //{
            //    var categories = new List<City>
            //    {
            //        new City
            //        {
            //            Id = 1,
            //            Name = "Test city 1",
            //            Country = "Test country 1"
            //        },
            //        new City
            //        {
            //            Id = 2,
            //            Name = "Test city 2",
            //            Country = "Test country 2"
            //        },
            //        new City
            //        {
            //            Id = 3,
            //            Name = "Test city 3",
            //            Country = "Test country 3"
            //        }
            //    };

            //    return new PagedList<City>(categories, categories.Count, pageNumber, pageSize);
            //});

            return this;
        }

        public MockCitiesRepository VerifyGetAllAsyncWithPagingParameters(Times times)
        {
            //Verify(r => r.GetAllAsync(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>()), times);

            return this;
        }
    }
}
