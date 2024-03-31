using Foodie.Common.Application.Requests.Commands.Abstractions;
using Foodie.Common.Results;
using MediatR;

namespace Foodie.Meals.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand : IAuditableCommand, IRequest<Result<CreateCategoryCommandResponse>>
    {
        public string Name { get; set; }
        public string User { get; set; }
    }
}
