using Foodie.Meals.Application.Functions.Meals.Commands.CreateMeal;
using Foodie.Meals.Application.Functions.Meals.Commands.UpdateMeal;
using Foodie.Meals.Application.Functions.Meals.Queries.GetMeals;
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
    public class MealsControllerTests
    {
        [Fact]
        public async Task MealsController_CreateMeal_ShouldReturnOkObjectResult()
        {
            var mediator = new MockMediatorForMeals()
                .MockSendingCreateMealCommand();
            var mealsController = new MealsController(mediator.Object);
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Email, "test@email.com") }, "TestAuthentication"));
            mealsController.ControllerContext = new ControllerContext();
            mealsController.ControllerContext.HttpContext = new DefaultHttpContext { User = user };
            var createMealCommand = new CreateMealCommand
            {
                Name = "Test meal",
                Description = "Test description",
                Price = 123,
                RestaurantId = 1
            };

            var result = await mealsController.CreateMeal(createMealCommand);

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            mediator.VerifySendingCreateMealCommand(Times.Once());
        }

        [Fact]
        public async Task MealsController_UpdateMealWithDifferentIdParameter_ShouldReturnBadRequestObjectResult()
        {
            var mediator = new MockMediatorForMeals()
                .MockSendingUpdateMealCommand();
            var mealsController = new MealsController(mediator.Object);
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Email, "test@email.com") }, "TestAuthentication"));
            mealsController.ControllerContext = new ControllerContext();
            mealsController.ControllerContext.HttpContext = new DefaultHttpContext { User = user };
            var updateMealCommand = new UpdateMealCommand
            {
                Id = 1,
                Name = "Test meal",
                Description = "Test description",
                Price = 123,
                RestaurantId = 1
            };

            var result = await mealsController.UpdateMeal(2, updateMealCommand);

            Assert.NotNull(result);
            Assert.IsType<BadRequestResult>(result);
            mediator.VerifySendingUpdateMealCommand(Times.Never());
        }

        [Fact]
        public async Task MealsController_UpdateMealWithEqualIdParameter_ShouldReturnOkObjectResult()
        {
            var mediator = new MockMediatorForMeals()
                .MockSendingUpdateMealCommand();
            var mealsController = new MealsController(mediator.Object);
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Email, "test@email.com") }, "TestAuthentication"));
            mealsController.ControllerContext = new ControllerContext();
            mealsController.ControllerContext.HttpContext = new DefaultHttpContext { User = user };
            var updateMealCommand = new UpdateMealCommand
            {
                Id = 1,
                Name = "Test meal",
                Description = "Test description",
                Price = 123,
                RestaurantId = 1
            };

            var result = await mealsController.UpdateMeal(1, updateMealCommand);

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            mediator.VerifySendingUpdateMealCommand(Times.Once());
        }

        [Fact]
        public async Task MealsController_DeleteMeal_ShouldReturnOkObjectResult()
        {
            var mediator = new MockMediatorForMeals()
                .MockSendingUpdateMealCommand();
            var mealsController = new MealsController(mediator.Object);
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Email, "test@email.com") }, "TestAuthentication"));
            mealsController.ControllerContext = new ControllerContext();
            mealsController.ControllerContext.HttpContext = new DefaultHttpContext { User = user };

            var result = await mealsController.DeleteMeal(1);

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            mediator.VerifySendingDeleteMealCommand(Times.Once());
        }

        [Fact]
        public async Task MealsController_GetMeal_ShouldReturnOkObjectResult()
        {
            var mediator = new MockMediatorForMeals()
                .MockSendingGetMealByIdQuery();
            var mealsController = new MealsController(mediator.Object);
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Email, "test@email.com") }, "TestAuthentication"));
            mealsController.ControllerContext = new ControllerContext();
            mealsController.ControllerContext.HttpContext = new DefaultHttpContext { User = user };

            var result = await mealsController.GetMeal(1);

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            mediator.VerifySendingGetMealByIdQuery(Times.Once());
        }

        [Fact]
        public async Task MealsController_GetMeals_ShouldReturnOkObjectResult()
        {
            var mediator = new MockMediatorForMeals()
                .MockSendingGetMealsQuery();
            var mealsController = new MealsController(mediator.Object);
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Email, "test@email.com") }, "TestAuthentication"));
            mealsController.ControllerContext = new ControllerContext();
            mealsController.ControllerContext.HttpContext = new DefaultHttpContext { User = user };
            var getMealsQuery = new GetMealsQuery
            {
                Name = "Test meal",
                RestaurantId = 1,
                PageNumber = 1,
                PageSize = 10,
            };

            var result = await mealsController.GetMeals(getMealsQuery);

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            mediator.VerifySendingGetMealsQuery(Times.Once());
        }
    }
}
