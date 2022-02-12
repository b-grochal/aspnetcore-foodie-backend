using Foodie.Basket.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetBasket()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBasket([FromBody] UpdateBasketCommand updateBasketCommand)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public async Task DeleteBasket()
        {
            throw new NotImplementedException();
        }

        [Route("checkout")]
        [HttpPost]
        public async Task<ActionResult> CheckoutAsync([FromBody] CheckoutBasketCommand checkoutBasketCommand)
        {
            throw new NotImplementedException();
        }
    }
}
