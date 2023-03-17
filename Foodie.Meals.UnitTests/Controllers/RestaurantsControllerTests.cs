using Foodie.Meals.Application.Functions.Restaurants.Commands.CreateRestaurant;
using Foodie.Meals.Application.Functions.Restaurants.Commands.UpdateRestaurant;
using Foodie.Meals.Application.Functions.Restaurants.Queries.GetRestaurantLocations;
using Foodie.Meals.Application.Functions.Restaurants.Queries.GetRestaurants;
using Foodie.Meals.Controllers;
using Foodie.Meals.UnitTests.Mocks.Mediators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Foodie.Meals.UnitTests.Controllers
{
    public class RestaurantsControllerTests
    {
        [Fact]
        public async Task RestaurantsController_CreateRestaurant_ShouldReturnOkObjectResult()
        {
            var mediator = new MockMediatorForRestaurants()
                .MockSendingCreateRestaurantCommand();
            var restaurantsController = new RestaurantsController(mediator.Object);
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Email, "test@email.com") }, "TestAuthentication"));
            restaurantsController.ControllerContext = new ControllerContext();
            restaurantsController.ControllerContext.HttpContext = new DefaultHttpContext { User = user };
            var createRestaurantCommand = new CreateRestaurantCommand
            {
                Name = "Test restaurant",
                CategoryIds = new List<int> { 1, 2, 3 }
            };

            var result = await restaurantsController.CreateRestaurant(createRestaurantCommand);

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            mediator.VerifySendingCreateRestaurantCommand(Times.Once());
        }

        [Fact]
        public async Task RestaurantsController_UpdateRestaurantWithDifferentIdParameter_ShouldReturnBadRequestObjectResult()
        {
            var mediator = new MockMediatorForRestaurants()
                .MockSendingUpdateRestaurantCommand();
            var restaurantsController = new RestaurantsController(mediator.Object);
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Email, "test@email.com") }, "TestAuthentication"));
            restaurantsController.ControllerContext = new ControllerContext();
            restaurantsController.ControllerContext.HttpContext = new DefaultHttpContext { User = user };
            var updateRestaurantCommand = new UpdateRestaurantCommand
            {
                Id = 1,
                Name = "Test restaurant",
                CategoryIds = new List<int> { 1, 2, 3 }
            };

            var result = await restaurantsController.UpdateRestaurant(2, updateRestaurantCommand);

            Assert.NotNull(result);
            Assert.IsType<BadRequestResult>(result);
            mediator.VerifySendingUpdateRestaurantCommand(Times.Never());
        }

        [Fact]
        public async Task RestaurantsController_UpdateRestaurantWithEqualIdParameter_ShouldReturnOkObjectResult()
        {
            var mediator = new MockMediatorForRestaurants()
                .MockSendingUpdateRestaurantCommand();
            var restaurantsController = new RestaurantsController(mediator.Object);
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Email, "test@email.com") }, "TestAuthentication"));
            restaurantsController.ControllerContext = new ControllerContext();
            restaurantsController.ControllerContext.HttpContext = new DefaultHttpContext { User = user };
            var updateRestaurantCommand = new UpdateRestaurantCommand
            {
                Id = 1,
                Name = "Test restaurant",
                CategoryIds = new List<int> { 1, 2, 3 }
            };

            var result = await restaurantsController.UpdateRestaurant(1, updateRestaurantCommand);

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            mediator.VerifySendingUpdateRestaurantCommand(Times.Once());
        }

        [Fact]
        public async Task RestaurantsController_DeleteRestauarant_ShouldReturnOkObjectResult()
        {
            var mediator = new MockMediatorForRestaurants()
                .MockSendingDeleteRestaurantCommand();
            var restaurantsController = new RestaurantsController(mediator.Object);
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Email, "test@email.com") }, "TestAuthentication"));
            restaurantsController.ControllerContext = new ControllerContext();
            restaurantsController.ControllerContext.HttpContext = new DefaultHttpContext { User = user };

            var result = await restaurantsController.DeleteRestaurant(1);

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            mediator.VerifySendingDeleteRestaurantCommand(Times.Once());
        }

        [Fact]
        public async Task RestaurantsController_GetRestaurant_ShouldReturnOkObjectResult()
        {
            var mediator = new MockMediatorForRestaurants()
                .MockSendingGetRestaurantByIdQuery();
            var restaurantsController = new RestaurantsController(mediator.Object);
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Email, "test@email.com") }, "TestAuthentication"));
            restaurantsController.ControllerContext = new ControllerContext();
            restaurantsController.ControllerContext.HttpContext = new DefaultHttpContext { User = user };

            var result = await restaurantsController.GetRestaurant(1);

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            mediator.VerifySendingGetRestaurantByIdQuery(Times.Once());
        }

        [Fact]
        public async Task RestaurantsController_GetRestaurants_ShouldReturnOkObjectResult()
        {
            var mediator = new MockMediatorForRestaurants()
                .MockSendingGetRestaurantsQuery();
            var restaurantsController = new RestaurantsController(mediator.Object);
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Email, "test@email.com") }, "TestAuthentication"));
            restaurantsController.ControllerContext = new ControllerContext();
            restaurantsController.ControllerContext.HttpContext = new DefaultHttpContext { User = user };
            var getRestaurantsQuery = new GetRestaurantsQuery
            {
                Name = "Test restaurant",
                CategoryId = 1,
                CityName = "Test city",
                PageNumber = 1,
                PageSize = 10,
            };

            var result = await restaurantsController.GetRestaurants(getRestaurantsQuery);

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            mediator.VerifySendingGetRestaurantsQuery(Times.Once());
        }

        [Fact]
        public async Task RestaurantsController_GetRestaurantLocations_ShouldReturnOkObjectResult()
        {
            var mediator = new MockMediatorForRestaurants()
                .MockSendingGetRestaurantLocationsQuery();
            var restaurantsController = new RestaurantsController(mediator.Object);
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Email, "test@email.com") }, "TestAuthentication"));
            restaurantsController.ControllerContext = new ControllerContext();
            restaurantsController.ControllerContext.HttpContext = new DefaultHttpContext { User = user };

            var result = await restaurantsController.GetRestaurantLocations(1, 1);

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            mediator.VerifySendingGetRestaurantLocationsQuery(Times.Once());
        }

        [Fact]
        public async Task RestaurantsController_GetRestaurantMeals_ShouldReturnOkObjectResult()
        {
            var mediator = new MockMediatorForRestaurants()
                .MockSendingGetRestaurantMealsQuery();
            var restaurantsController = new RestaurantsController(mediator.Object);
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Email, "test@email.com") }, "TestAuthentication"));
            restaurantsController.ControllerContext = new ControllerContext();
            restaurantsController.ControllerContext.HttpContext = new DefaultHttpContext { User = user };

            var result = await restaurantsController.GetRestaurantMeals(1);

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            mediator.VerifySendingGetRestaurantMealsQuery(Times.Once());
        }
    }
}
