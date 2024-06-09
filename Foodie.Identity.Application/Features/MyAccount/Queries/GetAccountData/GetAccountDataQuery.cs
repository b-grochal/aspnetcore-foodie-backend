using Foodie.Common.Application.Requests.Interfaces;
using Foodie.Common.Results;
using MediatR;

namespace Foodie.Identity.Application.Functions.MyAccount.Queries.GetAccountData
{
    public class GetAccountDataQuery : IRequest<Result<GetAccountDataQueryResponse>>, IApplicationUserIdRequest
    {
        public int ApplicationUserId { get; set; }
    }
}
