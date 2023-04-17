using MediatR;

namespace Foodie.Basket.API.Functions.CustomerBaskets.Queries.GetCustomerBasketByCustomerId
{
    public class GetCustomerBasketByCustomerIdQuery : IRequest<GetCustomerBasketByCustomerIdQueryResponse>
    {
        public string CustomerId { get; set; }

        public GetCustomerBasketByCustomerIdQuery(string customerId)
        {
            CustomerId = customerId;
        }
    }
}
