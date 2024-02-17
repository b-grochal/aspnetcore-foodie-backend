using Foodie.Common.Application.Commands;
using MediatR;

namespace Foodie.Meals.Application.Functions.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand : AuditableCommand, IRequest<CreateCategoryCommandResponse>
    {
        public string Name { get; set; }
    }
}
