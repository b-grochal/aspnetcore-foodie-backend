using Foodie.Common.Application.Requests.Abstractions;
using MediatR;

namespace Foodie.Basket.API.Functions.CustomerBaskets.Queries.GetCustomerBasketByCustomerId
{
    public class GetCustomerBasketByCustomerIdQuery : IRequest<GetCustomerBasketByCustomerIdQueryResponse>, IApplicationUserIdRequest
    {
        public int ApplicationUserId { get; set; }
    }
}
