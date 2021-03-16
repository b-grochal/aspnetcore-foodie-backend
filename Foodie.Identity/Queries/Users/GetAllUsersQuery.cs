using Foodie.Identity.Responses.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.Identity.Queries.Users
{
    public class GetAllUsersQuery : IRequest<IEnumerable<UserResponse>>
    {
    }
}
