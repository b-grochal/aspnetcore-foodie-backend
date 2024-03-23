using Foodie.Common.Application.Contracts.Infrastructure.Authentication;
using Foodie.Common.Application.Requests.Commands.Abstractions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Common.Application.Behaviours
{
    public class AuditableBehaviour<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IAuditableCommand, IRequest<TResponse>
    {
        private readonly IApplicationUserContext _applicationUserContext;

        public AuditableBehaviour(IApplicationUserContext applicationUserContext)
        {
            _applicationUserContext = applicationUserContext;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            request.User = _applicationUserContext.Email;

            return await next();
        }
    }
}
