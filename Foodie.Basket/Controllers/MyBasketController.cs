using Foodie.Basket.API.Functions.CustomerBaskets.Commands.CheckoutCustomerBasket;
using Foodie.Basket.API.Functions.CustomerBaskets.Commands.DeleteCustomerBasket;
using Foodie.Basket.API.Functions.CustomerBaskets.Commands.UpdateCustomerBasket;
using Foodie.Basket.API.Functions.CustomerBaskets.Queries.GetCustomerBasketByCustomerId;
using Foodie.Basket.Repositories.Interfaces;
using Foodie.Shared.Attributes;
using Foodie.Shared.Authorization;
using Foodie.Shared.Controllers;
using Foodie.Shared.Enums;
using Foodie.Shared.Extensions.Attributes;
using IdentityGrpc;
using MassTransit;
using MealsGrpc;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Foodie.Basket.Controllers
{
    [Route("api/my-basket")]
    [RequiredRoles(ApplicationUserRole.Customer)]
    public class MyBasketController : BaseController
    {
        public MyBasketController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        public async Task<IActionResult> GetMyBasket()
        {
            var result = await mediator.Send(new GetCustomerBasketByCustomerIdQuery(ApplicationUserId.Value));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMyBasket([FromBody] UpdateCustomerBasketCommand updateCustomerBasketCommand)
        {
            updateCustomerBasketCommand.CustomerId = ApplicationUserId.Value;
            var result = await mediator.Send(updateCustomerBasketCommand);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMyBasket()
        {
            await mediator.Send(new DeleteCustomerBasketCommand(ApplicationUserId.Value));
            return Ok();
        }

        [Route("checkout")]
        [HttpPost]
        public async Task<ActionResult> CheckoutMyBasket([FromBody] CheckoutCustomerBasketCommand checkoutCustomerBasketCommand)
        {
            checkoutCustomerBasketCommand.CustomerId = ApplicationUserId.Value;
            await mediator.Send(checkoutCustomerBasketCommand);
            return Ok();
        }
    }
}
