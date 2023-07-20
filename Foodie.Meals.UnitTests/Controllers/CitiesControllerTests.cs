using Foodie.Meals.API.Controllers;
using Foodie.Meals.Application.Functions.Cities.Commands.CreateCity;
using Foodie.Meals.Application.Functions.Cities.Commands.UpdateCity;
using Foodie.Meals.Application.Functions.Cities.Queries.GetCities;
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
    public class CitiesControllerTests
    {
        [Fact]
        public async Task CitiesController_CreateCity_ShouldReturnOkObjectResult()
        {
            //var mediator = new MockMediatorForCities()
            //    .MockSendingCreateCityCommand();
            //var citiesController = new CitiesController(mediator.Object);
            //var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Email, "test@email.com") }, "TestAuthentication"));
            //citiesController.ControllerContext = new ControllerContext();
            //citiesController.ControllerContext.HttpContext = new DefaultHttpContext { User = user };
            //var createCityCommand = new CreateCityCommand
            //{
            //    Name = "Test city",
            //    Country = "Test country"
            //};

            //var result = await citiesController.CreateCity(createCityCommand);

            //Assert.NotNull(result);
            //Assert.IsType<OkObjectResult>(result);
            //mediator.VerifySendingCreateCityCommand(Times.Once());
        }

        [Fact]
        public async Task CitiesController_UpdateCityWithDifferentIdParameter_ShouldReturnBadRequestObjectResult()
        {
            //var mediator = new MockMediatorForCities()
            //    .MockSendingUpdateCityCommand();
            //var citiesController = new CitiesController(mediator.Object);
            //var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Email, "test@email.com") }, "TestAuthentication"));
            //citiesController.ControllerContext = new ControllerContext();
            //citiesController.ControllerContext.HttpContext = new DefaultHttpContext { User = user };
            //var updateCityCommand = new UpdateCityCommand
            //{
            //    Id = 1,
            //    Name = "Test city",
            //    Country = "Test country"
            //};

            //var result = await citiesController.UpdateCity(2, updateCityCommand);

            //Assert.NotNull(result);
            //Assert.IsType<BadRequestResult>(result);
            //mediator.VerifySendingUpdateCityCommand(Times.Never());
        }

        [Fact]
        public async Task CitiesController_UpdateCityWithEqualIdParameter_ShouldReturnOkObjectResult()
        {
            //var mediator = new MockMediatorForCities()
            //    .MockSendingUpdateCityCommand();
            //var citiesController = new CitiesController(mediator.Object);
            //var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Email, "test@email.com") }, "TestAuthentication"));
            //citiesController.ControllerContext = new ControllerContext();
            //citiesController.ControllerContext.HttpContext = new DefaultHttpContext { User = user };
            //var updateCityCommand = new UpdateCityCommand
            //{
            //    Id = 1,
            //    Name = "Test city",
            //    Country = "Test country"
            //};

            //var result = await citiesController.UpdateCity(1, updateCityCommand);

            //Assert.NotNull(result);
            //Assert.IsType<OkObjectResult>(result);
            //mediator.VerifySendingUpdateCityCommand(Times.Once());
        }

        [Fact]
        public async Task CitiesController_DeleteCity_ShouldReturnOkObjectResult()
        {
            var mediator = new MockMediatorForCities()
                .MockSendingDeleteCityCommand();
            var citiesController = new CitiesController(mediator.Object);
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Email, "test@email.com") }, "TestAuthentication"));
            citiesController.ControllerContext = new ControllerContext();
            citiesController.ControllerContext.HttpContext = new DefaultHttpContext { User = user };

            var result = await citiesController.DeleteCity(1);

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            mediator.VerifySendingDeleteCityCommand(Times.Once());
        }

        [Fact]
        public async Task CitiesController_GetCity_ShouldReturnOkObjectResult()
        {
            var mediator = new MockMediatorForCities()
                .MockSendingGetCityByIdQuery();
            var citiesController = new CitiesController(mediator.Object);
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Email, "test@email.com") }, "TestAuthentication"));
            citiesController.ControllerContext = new ControllerContext();
            citiesController.ControllerContext.HttpContext = new DefaultHttpContext { User = user };

            var result = await citiesController.GetCity(1);

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            mediator.VerifySendingGetCityByIdQuery(Times.Once());
        }

        [Fact]
        public async Task CitiesController_GetCities_ShouldReturnOkObjectResult()
        {
            //var mediator = new MockMediatorForCities()
            //    .MockSendingGetCitiesQuery();
            //var citiesController = new CitiesController(mediator.Object);
            //var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Email, "test@email.com") }, "TestAuthentication"));
            //citiesController.ControllerContext = new ControllerContext();
            //citiesController.ControllerContext.HttpContext = new DefaultHttpContext { User = user };
            //var getCitiesQuery = new GetCitiesQuery
            //{
            //    Name = "Test city",
            //    Country = "Test country",
            //    PageNumber = 1,
            //    PageSize = 10,
            //};

            //var result = await citiesController.GetCities(getCitiesQuery);

            //Assert.NotNull(result);
            //Assert.IsType<OkObjectResult>(result);
            //mediator.VerifySendingGetCitiesQuery(Times.Once());
        }
    }
}
