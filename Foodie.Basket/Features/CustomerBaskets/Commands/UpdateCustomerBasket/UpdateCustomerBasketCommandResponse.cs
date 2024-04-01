using Foodie.Basket.API.Dtos;
using System.Collections.Generic;

namespace Foodie.Basket.API.Functions.CustomerBaskets.Commands.UpdateCustomerBasket
{
    public class UpdateCustomerBasketCommandResponse
    {
        public int LocationId { get; set; }
        public IReadOnlyCollection<CustomerBasketItemDto> Items { get; set; }
    }
}
