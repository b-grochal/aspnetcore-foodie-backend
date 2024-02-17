using Foodie.Common.Application.Authorization.Interfaces;
using Foodie.Common.Exceptions;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Shared.Behaviours
{
    public class RequestAuthorizationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IAuthorizer<TRequest>> authorizers;
        private readonly IMediator mediator;

        public RequestAuthorizationBehaviour(IEnumerable<IAuthorizer<TRequest>> authorizers, IMediator mediator)
        {
            this.authorizers = authorizers;
            this.mediator = mediator;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var requirements = new List<IAuthorizationRequirement>();

            foreach (var authorizer in authorizers)
            {
                authorizer.BuildPolicy(request);
                requirements.AddRange(authorizer.Requirements);
            }

            foreach (var requirement in requirements.Distinct())
            {
                var result = await mediator.Send(requirement, cancellationToken);
                if (!result.IsAuthorized)
                    throw new UnauthorizedException(result.FailureMessage);
            }

            return await next();
        }
    }
}
