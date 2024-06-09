using Foodie.Common.Application.Requests.Interfaces;
using Foodie.Common.Results;
using MediatR;

namespace Foodie.Basket.API.Functions.CustomerBaskets.Queries.GetCustomerBasketByCustomerId
{
    public class GetCustomerBasketByCustomerIdQuery : IRequest<Result<GetCustomerBasketByCustomerIdQueryResponse>>, IApplicationUserIdRequest
    {
        public int ApplicationUserId { get; set; }
    }
}
