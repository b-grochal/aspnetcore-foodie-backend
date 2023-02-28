using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Shared.Authorization
{
    public abstract class AbstractRequestAuthorizer<TRequest> : IAuthorizer<TRequest>
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
