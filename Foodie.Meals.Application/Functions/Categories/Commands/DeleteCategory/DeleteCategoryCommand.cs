using MediatR;

namespace Foodie.Meals.Application.Functions.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest<DeleteCategoryCommandResponse>
    {
        public int Id { get; set; }

        public DeleteCategoryCommand(int id)
        {
            this.Id = id;
        }
    }
}
