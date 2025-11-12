using Foodie.Common.Application.Contracts.Infrastructure.Authentication;
using Foodie.Common.Application.Requests.Interfaces;
using Foodie.Common.Enums;
using Foodie.Common.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Common.Application.Behaviours
{
    public class ApplicationUserLocationBehaviour<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>, IApplicationUserLocationRequest
        where TResponse : Result
    {
        private readonly IApplicationUserContext _applicationUserContext;

        public ApplicationUserLocationBehaviour(IApplicationUserContext applicationUserContext)
        {
            _applicationUserContext = applicationUserContext;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            request.Role = _applicationUserContext.Role;

            if (_applicationUserContext.Role == ApplicationUserRole.OrderHandler)
                request.LocationId = _applicationUserContext.LocationId;

            return await next();
        }
    }
}
