using Foodie.Common.Application.Authorization.Interfaces;
using System.Collections.Generic;

namespace Foodie.Common.Application.Authorization
{
    public abstract class RequestAuthorizer<TRequest> : IAuthorizer<TRequest>
    {
        private HashSet<IAuthorizationRequirement> requirements { get; set; } = new HashSet<IAuthorizationRequirement>();

        public IEnumerable<IAuthorizationRequirement> Requirements => requirements;

        protected void UseRequirement(IAuthorizationRequirement requirement)
        {
            if (requirement == null) return;
            requirements.Add(requirement);
        }

        public abstract void BuildPolicy(TRequest request);
    }
}
