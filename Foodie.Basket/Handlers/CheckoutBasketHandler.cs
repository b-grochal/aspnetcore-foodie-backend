using Foodie.Basket.Commands;
using IdentityGrpc;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Basket.Handlers
{
    public class CheckoutBasketHandler : IRequestHandler<CheckoutBasketCommand>
    {
        private readonly IdentityService.IdentityServiceClient identityServiceClient;

        public CheckoutBasketHandler(IdentityService.IdentityServiceClient identityServiceClient)
        {
            this.identityServiceClient = identityServiceClient;
        }

        public async Task<Unit> Handle(CheckoutBasketCommand request, CancellationToken cancellationToken)
        {
            var identityServiceRequest = new GetApplicationUserRequest { Id = request.ApplicationUserId };
            var call = identityServiceClient.GetApplicationUser(identityServiceRequest);
            return new Unit();
        }
    }
}
