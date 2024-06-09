using Foodie.Common.Application.Requests.Interfaces;
using Foodie.Common.Results;
using MediatR;
using System.Text.Json.Serialization;

namespace Foodie.Basket.API.Functions.CustomerBaskets.Commands.CheckoutCustomerBasket
{
    public class CheckoutCustomerBasketCommand : IRequest<Result>, IApplicationUserIdRequest
    {
        [JsonIgnore]
        public int ApplicationUserId { get; set; }
        public string Address { get; set; }
    }
}
