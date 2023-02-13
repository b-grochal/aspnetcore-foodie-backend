using MediatR;

namespace Foodie.Shared.Authorization
{
    public interface IAuthorizationHandler<TRequest> : IRequestHandler<TRequest, AuthorizationResult> where TRequest : IRequest<AuthorizationResult> { }
}
