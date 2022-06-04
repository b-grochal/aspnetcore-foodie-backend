using Foodie.Shared.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.Admins.Queries.GetAdmins
{
    public class GetAdminsQuery : PagedQuery, IRequest<GetAdminsQueryResponse>
    {
        public string Email { get; set; }
    }
}
