using Foodie.Basket.API.Functions.CustomerBaskets.Commands.CheckoutCustomerBasket;
using Foodie.Basket.API.Functions.CustomerBaskets.Commands.DeleteCustomerBasket;
using Foodie.Basket.API.Functions.CustomerBaskets.Commands.UpdateCustomerBasket;
using Foodie.Basket.API.Functions.CustomerBaskets.Queries.GetCustomerBasketByCustomerId;
using Foodie.Common.Api.Authorization;
using Foodie.Common.Api.Controllers;
using Foodie.Common.Enums;
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
            var result = await mediator.Send(new GetCustomerBasketByCustomerIdQuery());
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMyBasket([FromBody] UpdateCustomerBasketCommand updateCustomerBasketCommand)
        {
            var result = await mediator.Send(updateCustomerBasketCommand);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMyBasket()
        {
            await mediator.Send(new DeleteCustomerBasketCommand());
            return Ok();
        }

        [Route("checkout")]
        [HttpPost]
        public async Task<ActionResult> CheckoutMyBasket([FromBody] CheckoutCustomerBasketCommand checkoutCustomerBasketCommand)
        {
            await mediator.Send(checkoutCustomerBasketCommand);
            return Ok();
        }
    }
}
