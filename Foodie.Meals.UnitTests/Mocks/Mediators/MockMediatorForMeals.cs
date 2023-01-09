using Foodie.Meals.Application.Functions.Meals.Commands.CreateMeal;
using Foodie.Meals.Application.Functions.Meals.Commands.DeleteMeal;
using Foodie.Meals.Application.Functions.Meals.Commands.UpdateMeal;
using Foodie.Meals.Application.Functions.Meals.Queries.GetMealById;
using Foodie.Meals.Application.Functions.Meals.Queries.GetMeals;
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
    public class MockMediatorForMeals : Mock<IMediator>
    {
        public MockMediatorForMeals MockSendingCreateMealCommand()
        {
            Setup(m => m.Send(It.IsAny<CreateMealCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync((CreateMealCommand createMealCommand, CancellationToken cancellationToken) =>
            {
                return new CreateMealCommandResponse
                {
                    MealId = 1,
                    Name = createMealCommand.Name,
                    Description = createMealCommand.Description,
                    Price = createMealCommand.Price,
                    RestaurantId = createMealCommand.RestaurantId
                };
            });

            return this;
        }

        public MockMediatorForMeals VerifySendingCreateMealCommand(Times times)
        {
            Verify(m => m.Send(It.IsAny<CreateMealCommand>(), It.IsAny<CancellationToken>()), times);

            return this;
        }

        public MockMediatorForMeals MockSendingUpdateMealCommand()
        {
            Setup(m => m.Send(It.IsAny<UpdateMealCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync((UpdateMealCommand updateMealCommand, CancellationToken cancellationToken) =>
            {
                return new UpdateMealCommandResponse
                {
                    MealId = updateMealCommand.MealId,
                    Name = updateMealCommand.Name,
                    Description = updateMealCommand.Description,
                    Price = updateMealCommand.Price,
                    RestaurantId = updateMealCommand.RestaurantId,
                };
            });

            return this;
        }

        public MockMediatorForMeals VerifySendingUpdateMealCommand(Times times)
        {
            Verify(m => m.Send(It.IsAny<UpdateMealCommand>(), It.IsAny<CancellationToken>()), times);

            return this;
        }

        public MockMediatorForMeals MockSendingDeleteMealCommand()
        {
            Setup(m => m.Send(It.IsAny<DeleteMealCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync((DeleteMealCommand deleteMealCommand, CancellationToken cancellationToken) =>
            {
                return new DeleteMealCommandResponse
                {
                    MealId = deleteMealCommand.MealId
                };
            });

            return this;
        }

        public MockMediatorForMeals VerifySendingDeleteMealCommand(Times times)
        {
            Verify(m => m.Send(It.IsAny<DeleteMealCommand>(), It.IsAny<CancellationToken>()), times);

            return this;
        }

        public MockMediatorForMeals MockSendingGetMealByIdQuery()
        {
            Setup(m => m.Send(It.IsAny<GetMealByIdQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync((GetMealByIdQuery getMealByIdQuery, CancellationToken cancellationToken) =>
            {
                return new GetMealByIdQueryResponse
                {
                    MealId = getMealByIdQuery.MealId,
                    Name = "Test meal",
                    Description = "Test description",
                    Price = 123
                };
            });

            return this;
        }

        public MockMediatorForMeals VerifySendingGetMealByIdQuery(Times times)
        {
            Verify(m => m.Send(It.IsAny<GetMealByIdQuery>(), It.IsAny<CancellationToken>()), times);

            return this;
        }

        public MockMediatorForMeals MockSendingGetMealsQuery()
        {
            Setup(m => m.Send(It.IsAny<GetMealsQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync((GetMealsQuery getMealsQuery, CancellationToken cancellationToken) =>
            {
                return new GetMealsQueryResponse
                {
                    Name = getMealsQuery.Name,
                    RestaurantId = getMealsQuery.RestaurantId,
                    PageSize = getMealsQuery.PageSize,
                    CurrentPage = getMealsQuery.PageNumber,
                    TotalPages = 2,
                    Meals = new List<MealDto>
                    {
                        new MealDto
                        {
                            MealId = 1,
                            Name = "Test meal 1",
                            Price = 123
                        },
                        new MealDto
                        {
                            MealId = 2,
                            Name = "Test meal 2",
                            Price = 123
                        },
                        new MealDto
                        {
                            MealId = 3,
                            Name = "Test meal 3",
                            Price = 123
                        }
                    }
                };
            });

            return this;
        }

        public MockMediatorForMeals VerifySendingGetMealsQuery(Times times)
        {
            Verify(m => m.Send(It.IsAny<GetMealsQuery>(), It.IsAny<CancellationToken>()), times);

            return this;
        }
    }
}
