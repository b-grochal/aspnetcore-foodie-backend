using Foodie.Common.Application.Contracts.Infrastructure.Authentication;
using Foodie.Common.Application.Requests.Interfaces;
using Foodie.Common.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Common.Application.Behaviours
{
    public class ApplicationUserIdBehaviour<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>, IApplicationUserIdRequest
        where TResponse : Result
    {
        private readonly IApplicationUserContext _applicationUserContext;

        public ApplicationUserIdBehaviour(IApplicationUserContext applicationUserContext)
        {
            _applicationUserContext = applicationUserContext;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            request.ApplicationUserId = _applicationUserContext.Id;

            return await next();
        }
    }
}
