﻿using Foodie.Common.Application.Contracts.Infrastructure.Authentication;
using Foodie.Common.Application.Requests.Abstractions;
using Foodie.Common.Enums;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Common.Application.Behaviours
{
    public class ApplicationUserLocationBehaviour<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IApplicationUserLocationRequest, IRequest<TResponse>
    {
        private readonly IApplicationUserContext _applicationUserContext;

        public ApplicationUserLocationBehaviour(IApplicationUserContext applicationUserContext)
        {
            _applicationUserContext = applicationUserContext;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_applicationUserContext.Role == ApplicationUserRole.OrderHandler)
                request.LocationId = _applicationUserContext.LocationId;

            return await next();
        }
    }
}
