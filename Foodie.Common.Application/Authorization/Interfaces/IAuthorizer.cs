using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Common.Application.Authorization.Interfaces
{
    public interface IAuthorizer<T>
    {
        IEnumerable<IAuthorizationRequirement> Requirements { get; }
        void BuildPolicy(T instance);
    }
}
