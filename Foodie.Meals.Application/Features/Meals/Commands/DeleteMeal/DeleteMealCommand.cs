using Foodie.Common.Application.Requests.Commands.Interfaces;
using Foodie.Common.Results;
using MediatR;

namespace Foodie.Meals.Application.Functions.Meals.Commands.DeleteMeal
{
    public class DeleteMealCommand : IRequest<Result<DeleteMealCommandResponse>>, IAuditableCommand
    {
        public int Id { get; set; }

        public int ApplicationUserId { get; set; }

        public string ApplicationUserEmail { get; set; }

        public DeleteMealCommand(int id)
        {
            this.Id = id;
        }
    }
}
