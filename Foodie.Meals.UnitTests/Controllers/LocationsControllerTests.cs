using Foodie.Meals.API.Controllers;
using Foodie.Meals.Application.Functions.Locations.Commands.CreateLocation;
using Foodie.Meals.Application.Functions.Locations.Commands.UpdateLocation;
using Foodie.Meals.Application.Functions.Locations.Queries.GetLocations;
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
    public class LocationsControllerTests
    {
        [Fact]
        public async Task LocationsController_CreateLocation_ShouldReturnOkObjectResult()
        {
            var mediator = new MockMediatorForLocations()
                .MockSendingCreateLocationCommand();
            var locationsController = new LocationsController(mediator.Object);
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Email, "test@email.com") }, "TestAuthentication"));
            locationsController.ControllerContext = new ControllerContext();
            locationsController.ControllerContext.HttpContext = new DefaultHttpContext { User = user };
            var createLocationCommand = new CreateLocationCommand
            {
                Address = "Test address",
                PhoneNumber = "123-456-789",
                Email = "test@email.com",
                CityId = 1,
                RestaurantId = 1
            };

            var result = await locationsController.CreateLocation(createLocationCommand);

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            mediator.VerifySendingCreateLocationCommand(Times.Once());
        }

        [Fact]
        public async Task LocationsController_UpdateLocationWithDifferentIdParameter_ShouldReturnBadRequestObjectResult()
        {
            var mediator = new MockMediatorForLocations()
                .MockSendingUpdateLocationCommand();
            var locationsController = new LocationsController(mediator.Object);
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Email, "test@email.com") }, "TestAuthentication"));
            locationsController.ControllerContext = new ControllerContext();
            locationsController.ControllerContext.HttpContext = new DefaultHttpContext { User = user };
            var updateLocationCommand = new UpdateLocationCommand
            {
                Id = 1,
                Address = "Test address",
                PhoneNumber = "123-456-789",
                Email = "test@email.com",
                CityId = 1,
                RestaurantId = 1
            };

            var result = await locationsController.UpdateLocation(2, updateLocationCommand);

            Assert.NotNull(result);
            Assert.IsType<BadRequestResult>(result);
            mediator.VerifySendingUpdateLocationCommand(Times.Never());
        }

        [Fact]
        public async Task LocationsController_UpdateLocationWithEqualIdParameter_ShouldReturnOkObjectResult()
        {
            var mediator = new MockMediatorForLocations()
                .MockSendingUpdateLocationCommand();
            var locationsController = new LocationsController(mediator.Object);
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Email, "test@email.com") }, "TestAuthentication"));
            locationsController.ControllerContext = new ControllerContext();
            locationsController.ControllerContext.HttpContext = new DefaultHttpContext { User = user };
            var updateLocationCommand = new UpdateLocationCommand
            {
                Id = 1,
                Address = "Test address",
                PhoneNumber = "123-456-789",
                Email = "test@email.com",
                CityId = 1,
                RestaurantId = 1
            };

            var result = await locationsController.UpdateLocation(1, updateLocationCommand);

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            mediator.VerifySendingUpdateLocationCommand(Times.Once());
        }

        [Fact]
        public async Task LocationsController_DeleteLocation_ShouldReturnOkObjectResult()
        {
            var mediator = new MockMediatorForLocations()
                .MockSendingDeleteLocationCommand();
            var locationsController = new LocationsController(mediator.Object);
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Email, "test@email.com") }, "TestAuthentication"));
            locationsController.ControllerContext = new ControllerContext();
            locationsController.ControllerContext.HttpContext = new DefaultHttpContext { User = user };

            var result = await locationsController.DeleteLocation(1);

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            mediator.VerifySendingDeleteLocationCommand(Times.Once());
        }

        [Fact]
        public async Task LocationsController_GetLocation_ShouldReturnOkObjectResult()
        {
            var mediator = new MockMediatorForLocations()
                .MockSendingGetLocationByIdQuery();
            var locationsController = new LocationsController(mediator.Object);
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Email, "test@email.com") }, "TestAuthentication"));
            locationsController.ControllerContext = new ControllerContext();
            locationsController.ControllerContext.HttpContext = new DefaultHttpContext { User = user };

            var result = await locationsController.GetLocation(1);

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            mediator.VerifySendingGetLocationByIdQuery(Times.Once());
        }

        [Fact]
        public async Task LocationsController_GetLocations_ShouldReturnOkObjectResult()
        {
            var mediator = new MockMediatorForLocations()
                .MockSendingGetLocationsQuery();
            var locationsController = new LocationsController(mediator.Object);
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Email, "test@email.com") }, "TestAuthentication"));
            locationsController.ControllerContext = new ControllerContext();
            locationsController.ControllerContext.HttpContext = new DefaultHttpContext { User = user };
            var getCitiesQuery = new GetLocationsQuery
            {
                CityId = 1,
                RestaurantId = 1,
                PageNumber = 1,
                PageSize = 10,
            };

            var result = await locationsController.GetLocations(getCitiesQuery);

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            mediator.VerifySendingGetLocationsQuery(Times.Once());
        }
    }
}
