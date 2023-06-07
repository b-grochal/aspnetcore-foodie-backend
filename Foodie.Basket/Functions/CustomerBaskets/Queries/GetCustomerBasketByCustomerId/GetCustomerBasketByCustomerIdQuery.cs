using MediatR;

namespace Foodie.Basket.API.Functions.CustomerBaskets.Queries.GetCustomerBasketByCustomerId
{
    public class GetCustomerBasketByCustomerIdQuery : IRequest<GetCustomerBasketByCustomerIdQueryResponse>
    {
        public int CustomerId { get; set; }

        public GetCustomerBasketByCustomerIdQuery(int customerId)
        {
            CustomerId = customerId;
        }
    }
}
