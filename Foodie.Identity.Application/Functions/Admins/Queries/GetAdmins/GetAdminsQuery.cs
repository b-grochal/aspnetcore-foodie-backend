using Foodie.Common.Application.Queries;
using MediatR;

namespace Foodie.Identity.Application.Functions.Admins.Queries.GetAdmins
{
    public class GetAdminsQuery : PagedQuery, IRequest<GetAdminsQueryResponse>
    {
        public string Email { get; set; }
    }
}
