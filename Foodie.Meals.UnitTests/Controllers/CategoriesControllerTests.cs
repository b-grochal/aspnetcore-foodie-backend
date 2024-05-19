//using Foodie.Meals.API.Controllers;
//using Foodie.Meals.Application.Functions.Categories.Commands.CreateCategory;
//using Foodie.Meals.Application.Functions.Categories.Commands.UpdateCategory;
//using Foodie.Meals.Application.Functions.Categories.Queries.GetCategories;
//using Foodie.Meals.Application.Functions.Categories.Queries.GetCategoryById;
//using Foodie.Meals.UnitTests.Mocks.Mediators;
//using MediatR;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Moq;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Claims;
//using System.Text;
//using System.Threading.Tasks;
//using Xunit;

//namespace Foodie.Meals.UnitTests.Controllers
//{
//    public class CategoriesControllerTests
//    {
//        [Fact]
//        public async Task CategoriesController_CreateCategory_ShouldReturnOkObjectResult()
//        {
//            var mediator = new MockMediatorForCategories()
//                .MockSendingCreateCategoryCommand();
//            var categoriesController = new CategoriesController(mediator.Object);
//            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Email, "test@email.com") }, "TestAuthentication"));
//            categoriesController.ControllerContext = new ControllerContext();
//            categoriesController.ControllerContext.HttpContext = new DefaultHttpContext { User = user };
//            var createCategoryCommand = new CreateCategoryCommand
//            {
//                Name = "Test category"
//            };

//            var result = await categoriesController.CreateCategory(createCategoryCommand);

//            Assert.NotNull(result);
//            Assert.IsType<OkObjectResult>(result);
//            mediator.VerifySendingCreateCategoryCommand(Times.Once());
//        }

//        [Fact]
//        public async Task CategoriesController_UpdateCategoryWithDifferentIdParameter_ShouldReturnBadRequestObjectResult()
//        {
//            var mediator = new MockMediatorForCategories()
//                .MockSendingUpdateCategoryCommand();
//            var categoriesController = new CategoriesController(mediator.Object);
//            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Email, "test@email.com") }, "TestAuthentication"));
//            categoriesController.ControllerContext = new ControllerContext();
//            categoriesController.ControllerContext.HttpContext = new DefaultHttpContext { User = user };
//            var updateCategoryCommand = new UpdateCategoryCommand
//            {
//                Id = 1,
//                Name = "Test category"
//            };

//            var result = await categoriesController.UpdateCategory(2, updateCategoryCommand);

//            Assert.NotNull(result);
//            Assert.IsType<BadRequestResult>(result);
//            mediator.VerifySendingUpdateCategoryCommand(Times.Never());
//        }

//        [Fact]
//        public async Task CategoriesController_UpdateCategoryWithEqualIdParameter_ShouldReturnOkObjectResult()
//        {
//            var mediator = new MockMediatorForCategories()
//                .MockSendingUpdateCategoryCommand();
//            var categoriesController = new CategoriesController(mediator.Object);
//            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Email, "test@email.com") }, "TestAuthentication"));
//            categoriesController.ControllerContext = new ControllerContext();
//            categoriesController.ControllerContext.HttpContext = new DefaultHttpContext { User = user };
//            var updateCategoryCommand = new UpdateCategoryCommand
//            {
//                Id = 1,
//                Name = "Test category"
//            };

//            var result = await categoriesController.UpdateCategory(1, updateCategoryCommand);

//            Assert.NotNull(result);
//            Assert.IsType<OkObjectResult>(result);
//            mediator.VerifySendingUpdateCategoryCommand(Times.Once());
//        }

//        [Fact]
//        public async Task CategoriesController_DeleteCategory_ShouldReturnOkObjectResult()
//        {
//            var mediator = new MockMediatorForCategories()
//                .MockSendingDeleteCategoryCommand();
//            var categoriesController = new CategoriesController(mediator.Object);
//            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Email, "test@email.com") }, "TestAuthentication"));
//            categoriesController.ControllerContext = new ControllerContext();
//            categoriesController.ControllerContext.HttpContext = new DefaultHttpContext { User = user };

//            var result = await categoriesController.DeleteCategory(1);

//            Assert.NotNull(result);
//            Assert.IsType<OkObjectResult>(result);
//            mediator.VerifySendingDeleteCategoryCommand(Times.Once());
//        }

//        [Fact]
//        public async Task CategoriesController_GetCategory_ShouldReturnOkObjectResult()
//        {
//            var mediator = new MockMediatorForCategories()
//                .MockSendingGetCategoryByIdQuery();
//            var categoriesController = new CategoriesController(mediator.Object);
//            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Email, "test@email.com") }, "TestAuthentication"));
//            categoriesController.ControllerContext = new ControllerContext();
//            categoriesController.ControllerContext.HttpContext = new DefaultHttpContext { User = user };

//            var result = await categoriesController.GetCategory(1);

//            Assert.NotNull(result);
//            Assert.IsType<OkObjectResult>(result);
//            mediator.VerifySendingGetCategoryByIdQuery(Times.Once());
//        }

//        [Fact]
//        public async Task CategoriesController_GetCategories_ShouldReturnOkObjectResult()
//        {
//            var mediator = new MockMediatorForCategories()
//                .MockSendingGetCategoriesQuery();
//            var categoriesController = new CategoriesController(mediator.Object);
//            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Email, "test@email.com") }, "TestAuthentication"));
//            categoriesController.ControllerContext = new ControllerContext();
//            categoriesController.ControllerContext.HttpContext = new DefaultHttpContext { User = user };
//            var getCategoriesQuery = new GetCategoriesQuery
//            {
//                Name = "Test category",
//                PageNumber = 1,
//                PageSize = 10,
//            };

//            var result = await categoriesController.GetCategories(getCategoriesQuery);

//            Assert.NotNull(result);
//            Assert.IsType<OkObjectResult>(result);
//            mediator.VerifySendingGetCategoriesQuery(Times.Once());
//        }
//    }
//}
