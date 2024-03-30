using Foodie.Common.Application.Requests.Abstractions;
using MediatR;
using System.Text.Json.Serialization;

namespace Foodie.Basket.API.Functions.CustomerBaskets.Commands.CheckoutCustomerBasket
{
    public class CheckoutCustomerBasketCommand : IRequest, IApplicationUserIdRequest
    {
        [JsonIgnore]
        public int ApplicationUserId { get; set; }
        public string Address { get; set; }
    }
}
