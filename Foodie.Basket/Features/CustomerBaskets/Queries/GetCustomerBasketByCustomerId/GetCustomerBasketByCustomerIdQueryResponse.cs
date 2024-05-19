using Foodie.Basket.API.Dtos;
using System.Collections.Generic;

namespace Foodie.Basket.API.Functions.CustomerBaskets.Queries.GetCustomerBasketByCustomerId
{
    public class GetCustomerBasketByCustomerIdQueryResponse
    {
        public int LocationId { get; set; }
        public IReadOnlyCollection<CustomerBasketItemDto> Items { get; set; }
    }
}
