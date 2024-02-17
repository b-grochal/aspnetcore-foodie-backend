using MediatR;

namespace Foodie.Common.Application.Authorization.Interfaces
{
    public interface IAuthorizationHandler<TRequest> : IRequestHandler<TRequest, IAuthorizationResult> where TRequest : IRequest<IAuthorizationResult> { }
}
