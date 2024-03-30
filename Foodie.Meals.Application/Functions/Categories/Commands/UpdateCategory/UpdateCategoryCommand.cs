using Foodie.Common.Application.Requests.Commands.Abstractions;
using MediatR;

namespace Foodie.Meals.Application.Functions.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : IAuditableCommand, IRequest<UpdateCategoryCommandResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string User { get; set; }
    }
}
