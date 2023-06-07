using Foodie.Basket.API.Dtos;
using MediatR;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Foodie.Basket.API.Functions.CustomerBaskets.Commands.UpdateCustomerBasket
{
    public class UpdateCustomerBasketCommand : IRequest<UpdateCustomerBasketCommandResponse>
    {
        [JsonIgnore]
        public int CustomerId { get; set; }
        public int LocationId { get; set; }
        public IReadOnlyCollection<CustomerBasketItemDto> Items { get; set; }
    }
}
