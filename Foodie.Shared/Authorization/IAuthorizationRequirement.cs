using MediatR;

namespace Foodie.Shared.Authorization
{
    public interface IAuthorizationRequirement : IRequest<AuthorizationResult> { }
}
