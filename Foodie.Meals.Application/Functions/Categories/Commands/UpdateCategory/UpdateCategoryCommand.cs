using Foodie.Common.Application.Commands;
using MediatR;

namespace Foodie.Meals.Application.Functions.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : AuditableCommand, IRequest<UpdateCategoryCommandResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
