using MediatR;

namespace Foodie.Common.Application.Authorization.Interfaces
{
    public interface IAuthorizationRequirement : IRequest<IAuthorizationResult> { }
}
