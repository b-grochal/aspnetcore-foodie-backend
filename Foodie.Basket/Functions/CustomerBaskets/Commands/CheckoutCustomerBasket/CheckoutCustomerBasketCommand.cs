using MediatR;
using System.Text.Json.Serialization;

namespace Foodie.Basket.API.Functions.CustomerBaskets.Commands.CheckoutCustomerBasket
{
    public class CheckoutCustomerBasketCommand : IRequest
    {
        [JsonIgnore]
        public int CustomerId { get; set; }
        public string Address { get; set; }
    }
}
