using Foodie.Meals.Application.Functions.Restaurants.Commands.CreateRestaurant;
using Foodie.Meals.Application.Functions.Restaurants.Commands.DeleteRestaurant;
using Foodie.Meals.Application.Functions.Restaurants.Commands.UpdateRestaurant;
using Foodie.Meals.Application.Functions.Restaurants.Queries.GetRestaurantById;
using Foodie.Meals.Application.Functions.Restaurants.Queries.GetRestaurantLocations;
using Foodie.Meals.Application.Functions.Restaurants.Queries.GetRestaurantMealsById;
using Foodie.Meals.Application.Functions.Restaurants.Queries.GetRestaurants;
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
    public class MockMediatorForRestaurants : Mock<IMediator>
    {
        public MockMediatorForRestaurants MockSendingCreateRestaurantCommand()
        {
            Setup(m => m.Send(It.IsAny<CreateRestaurantCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync((CreateRestaurantCommand createRestaurantCommand, CancellationToken cancellationToken) =>
            {
                return new CreateRestaurantCommandResponse
                {
                    RestaurantId = 1,
                    Name = createRestaurantCommand.Name
                };
            });

            return this;
        }

        public MockMediatorForRestaurants VerifySendingCreateRestaurantCommand(Times times)
        {
            Verify(m => m.Send(It.IsAny<CreateRestaurantCommand>(), It.IsAny<CancellationToken>()), times);

            return this;
        }

        public MockMediatorForRestaurants MockSendingUpdateRestaurantCommand()
        {
            Setup(m => m.Send(It.IsAny<UpdateRestaurantCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync((UpdateRestaurantCommand updateRestaurantCommand, CancellationToken cancellationToken) =>
            {
                return new UpdateRestaurantCommandResponse
                {
                    RestaurantId = updateRestaurantCommand.RestaurantId,
                    Name = updateRestaurantCommand.Name
                };
            });

            return this;
        }

        public MockMediatorForRestaurants VerifySendingUpdateRestaurantCommand(Times times)
        {
            Verify(m => m.Send(It.IsAny<UpdateRestaurantCommand>(), It.IsAny<CancellationToken>()), times);

            return this;
        }

        public MockMediatorForRestaurants MockSendingDeleteRestaurantCommand()
        {
            Setup(m => m.Send(It.IsAny<DeleteRestaurantCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync((DeleteRestaurantCommand deleteRestaurantCommand, CancellationToken cancellationToken) =>
            {
                return new DeleteRestaurantCommandResponse
                {
                    RestaurantId = deleteRestaurantCommand.RestaurantId
                };
            });

            return this;
        }

        public MockMediatorForRestaurants VerifySendingDeleteRestaurantCommand(Times times)
        {
            Verify(m => m.Send(It.IsAny<DeleteRestaurantCommand>(), It.IsAny<CancellationToken>()), times);

            return this;
        }

        public MockMediatorForRestaurants MockSendingGetRestaurantByIdQuery()
        {
            Setup(m => m.Send(It.IsAny<GetRestaurantByIdQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync((GetRestaurantByIdQuery getRestaurantByIdQuery, CancellationToken cancellationToken) =>
            {
                return new GetRestaurantByIdQueryResponse
                {
                    RestaurantId = getRestaurantByIdQuery.RestaurantId,
                    Name = "Test restaurant"
                };
            });

            return this;
        }

        public MockMediatorForRestaurants VerifySendingGetRestaurantByIdQuery(Times times)
        {
            Verify(m => m.Send(It.IsAny<GetRestaurantByIdQuery>(), It.IsAny<CancellationToken>()), times);

            return this;
        }

        public MockMediatorForRestaurants MockSendingGetRestaurantsQuery()
        {
            Setup(m => m.Send(It.IsAny<GetRestaurantsQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync((GetRestaurantsQuery getRestaurantsQuery, CancellationToken cancellationToken) =>
            {
                return new GetRestaurantsQueryResponse
                {
                    Name = getRestaurantsQuery.Name,
                    CategoryId = getRestaurantsQuery.CategoryId,
                    CityName = getRestaurantsQuery.CityName,
                    PageSize = getRestaurantsQuery.PageSize,
                    CurrentPage = getRestaurantsQuery.PageNumber,
                    TotalPages = 2,
                    Restaurants = new List<RestauranatDto>
                    {
                        new RestauranatDto
                        {
                            RestaurantId = 1,
                            Name = "Test restaurant 1"
                        },
                        new RestauranatDto
                        {
                            RestaurantId = 2,
                            Name = "Test restaurant 2"
                        },
                        new RestauranatDto
                        {
                            RestaurantId = 3,
                            Name = "Test restaurant 3"
                        }
                    }
                };
            });

            return this;
        }

        public MockMediatorForRestaurants VerifySendingGetRestaurantsQuery(Times times)
        {
            Verify(m => m.Send(It.IsAny<GetRestaurantsQuery>(), It.IsAny<CancellationToken>()), times);

            return this;
        }

        public MockMediatorForRestaurants MockSendingGetRestaurantLocationsQuery()
        {
            Setup(m => m.Send(It.IsAny<GetRestaurantLocationsQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync((GetRestaurantLocationsQuery getRestaurantLocationsQuery, CancellationToken cancellationToken) =>
            {
                return new List<RestaurantLocationDto>
                {
                    new RestaurantLocationDto
                    {
                        LocationId = 1,
                        Address = "Test address",
                        PhoneNumber = "123-456-789",
                        Email = "test@email.com",
                        CityName = "Test city"
                    },
                    new RestaurantLocationDto
                    {
                        LocationId = 2,
                        Address = "Test address",
                        PhoneNumber = "123-456-789",
                        Email = "test@email.com",
                        CityName = "Test city"
                    },
                    new RestaurantLocationDto
                    {
                        LocationId = 3,
                        Address = "Test address",
                        PhoneNumber = "123-456-789",
                        Email = "test@email.com",
                        CityName = "Test city"
                    },
                };
            });

            return this;
        }

        public MockMediatorForRestaurants VerifySendingGetRestaurantLocationsQuery(Times times)
        {
            Verify(m => m.Send(It.IsAny<GetRestaurantLocationsQuery>(), It.IsAny<CancellationToken>()), times);

            return this;
        }

        public MockMediatorForRestaurants MockSendingGetRestaurantMealsQuery()
        {
            Setup(m => m.Send(It.IsAny<GetRestaurantMealsQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync((GetRestaurantMealsQuery getRestaurantMealsQuery, CancellationToken cancellationToken) =>
            {
                return new List<RestaurantMealDto>
                {
                    new RestaurantMealDto
                    {
                        MealId = 1,
                        Name = "Test meal 1",
                        Description = "123-456-789",
                        Price = 123
                    },
                    new RestaurantMealDto
                    {
                        MealId = 2,
                        Name = "Test meal 2",
                        Description = "123-456-789",
                        Price = 123
                    },
                    new RestaurantMealDto
                    {
                        MealId = 3,
                        Name = "Test meal 3",
                        Description = "123-456-789",
                        Price = 123
                    },
                };
            });

            return this;
        }

        public MockMediatorForRestaurants VerifySendingGetRestaurantMealsQuery(Times times)
        {
            Verify(m => m.Send(It.IsAny<GetRestaurantMealsQuery>(), It.IsAny<CancellationToken>()), times);

            return this;
        }
    }
}
