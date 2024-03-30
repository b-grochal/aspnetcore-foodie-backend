using Foodie.Common.Application.Requests.Abstractions;
using MediatR;

namespace Foodie.Basket.API.Functions.CustomerBaskets.Commands.DeleteCustomerBasket
{
    public class DeleteCustomerBasketCommand : IRequest, IApplicationUserIdRequest
    {
        public int ApplicationUserId { get; set; }
    }
}
