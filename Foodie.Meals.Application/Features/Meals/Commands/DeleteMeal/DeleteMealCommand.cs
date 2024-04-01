using Foodie.Common.Results;
using MediatR;

namespace Foodie.Meals.Application.Functions.Meals.Commands.DeleteMeal
{
    public class DeleteMealCommand : IRequest<Result<DeleteMealCommandResponse>>
    {
        public int Id { get; set; }

        public DeleteMealCommand(int id)
        {
            this.Id = id;
        }
    }
}
