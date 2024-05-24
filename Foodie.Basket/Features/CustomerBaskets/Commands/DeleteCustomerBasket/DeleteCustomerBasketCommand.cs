using Foodie.Common.Application.Requests.Interfaces;
using Foodie.Common.Results;
using MediatR;

namespace Foodie.Basket.API.Functions.CustomerBaskets.Commands.DeleteCustomerBasket
{
    public class DeleteCustomerBasketCommand : IRequest<Result>, IApplicationUserIdRequest
    {
        public int ApplicationUserId { get; set; }
    }
}
