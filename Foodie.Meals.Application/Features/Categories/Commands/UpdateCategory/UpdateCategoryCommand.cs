using Foodie.Common.Application.Requests.Commands.Interfaces;
using Foodie.Common.Results;
using MediatR;

namespace Foodie.Meals.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : IAuditableCommand, IRequest<Result<UpdateCategoryCommandResponse>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ApplicationUserId { get; set; }
        public string ApplicationUserEmail { get; set; }
    }
}
