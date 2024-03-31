using Foodie.Common.Results;
using MediatR;

namespace Foodie.Meals.Application.Features.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest<Result<DeleteCategoryCommandResponse>>
    {
        public int Id { get; set; }

        public DeleteCategoryCommand(int id)
        {
            Id = id;
        }
    }
}
