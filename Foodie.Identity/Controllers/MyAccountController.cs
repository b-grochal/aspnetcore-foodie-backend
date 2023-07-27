using Foodie.Identity.Application.Functions.MyAccount.Commands.ActivateAccount;
using Foodie.Shared.Attributes;
using Foodie.Shared.Controllers;
using Foodie.Shared.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Foodie.Identity.API.Controllers
{
    [Route("api/my-account")]
    public class MyAccountController : BaseController
    {
        public MyAccountController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [Route("activate-account")]
        public async Task<IActionResult> ActivateAccount([FromBody] ActivateAccountCommand createAdminCommand)
        {
            var result = await mediator.Send(createAdminCommand);
            return Ok(result);
        }
    }
}
