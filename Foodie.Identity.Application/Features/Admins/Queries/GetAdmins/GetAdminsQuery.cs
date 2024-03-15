using Foodie.Common.Application.Queries;
using Foodie.Common.Results;
using MediatR;

namespace Foodie.Identity.Application.Functions.Admins.Queries.GetAdmins
{
    public class GetAdminsQuery : PagedQuery, IRequest<Result<GetAdminsQueryResponse>>
    {
        public string Email { get; set; }
    }
}
