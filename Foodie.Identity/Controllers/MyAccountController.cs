using Foodie.Identity.Application.Functions.MyAccount.Commands.ActivateAccount;
using Foodie.Identity.Application.Functions.MyAccount.Commands.UpdateAccountData;
using Foodie.Identity.Application.Functions.MyAccount.Queries.GetAccountData;
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

        [HttpGet]
        [RequiredRoles(ApplicationUserRole.Admin, ApplicationUserRole.OrderHandler, ApplicationUserRole.Customer)]
        public async Task<IActionResult> GetAccountData()
        {
            var result = await mediator.Send(new GetAccountDataQuery(ApplicationUserId.Value));
            return Ok(result);
        }

        [HttpPut]
        [RequiredRoles(ApplicationUserRole.Admin, ApplicationUserRole.OrderHandler, ApplicationUserRole.Customer)]
        public async Task<IActionResult> UpdateAccountData([FromBody] UpdateAccountDataCommand updateAccountDataCommand)
        {
            updateAccountDataCommand.ApplicationUserId = ApplicationUserId.Value;
            await mediator.Send(updateAccountDataCommand);
            return NoContent();
        }
    }
}
