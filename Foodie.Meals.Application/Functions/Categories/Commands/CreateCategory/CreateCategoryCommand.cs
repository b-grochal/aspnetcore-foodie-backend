using Foodie.Common.Application.Requests.Commands.Abstractions;
using MediatR;

namespace Foodie.Meals.Application.Functions.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand : IAuditableCommand, IRequest<CreateCategoryCommandResponse>
    {
        public string Name { get; set; }
        public string User { get ; set ; }
    }
}
