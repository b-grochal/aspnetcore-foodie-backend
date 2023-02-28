using Foodie.Orders.Application.Contracts.Infrastructure.Repositories;
using Foodie.Shared.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Authorization.Requirements
{
    public class SameLocationLikeOrderRequirement : IAuthorizationRequirement
    {
        public int OrderId { get; set; }
        public int LocationId { get; set; }
    }

    public class SameLocationLikeOrderRequirementHandler : IAuthorizationHandler<SameLocationLikeOrderRequirement>
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IContractorsRepository _contractorsRepository;

        public SameLocationLikeOrderRequirementHandler(IOrdersRepository ordersRepository, IContractorsRepository contractorsRepository)
        {
            _ordersRepository = ordersRepository;
            _contractorsRepository = contractorsRepository;
        }

        public async Task<AuthorizationResult> Handle(SameLocationLikeOrderRequirement request, CancellationToken cancellationToken)
        {
            var order = await _ordersRepository.GetByIdAsync(request.OrderId);
            var contractor = await _contractorsRepository.GetByIdAsync(order.GetContractorId.Value);

            if (contractor.LocationId != request.LocationId)
                return AuthorizationResult.Fail("Access forbidden");

            return AuthorizationResult.Succeed();
        }
    }
}
