using Foodie.Basket.API.Functions.CustomerBaskets.Commands.CheckoutCustomerBasket;
using Foodie.Basket.API.Functions.CustomerBaskets.Commands.DeleteCustomerBasket;
using Foodie.Basket.API.Functions.CustomerBaskets.Commands.UpdateCustomerBasket;
using Foodie.Basket.API.Functions.CustomerBaskets.Queries.GetCustomerBasketByCustomerId;
using Foodie.Common.Api.Authorization;
using Foodie.Common.Enums;
using Foodie.Shared.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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
