using Foodie.Common.Api.Authorization;
using Foodie.Common.Api.Controllers;
using Foodie.Common.Enums;
using Foodie.Identity.Application.Features.MyAccount.Commands.ActivateAccount;
using Foodie.Identity.Application.Features.MyAccount.Commands.ChangeEmail;
using Foodie.Identity.Application.Features.MyAccount.Commands.ChangePassword;
using Foodie.Identity.Application.Features.MyAccount.Commands.ResetPassword;
using Foodie.Identity.Application.Features.MyAccount.Commands.SetPassword;
using Foodie.Identity.Application.Features.MyAccount.Commands.UpdateAccountData;
using Foodie.Identity.Application.Functions.MyAccount.Queries.GetAccountData;
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

        [HttpPost]
        [Route("change-password")]
        [RequiredRoles(ApplicationUserRole.Admin, ApplicationUserRole.OrderHandler, ApplicationUserRole.Customer)]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordCommand changePassowrdCommand)
        {
            changePassowrdCommand.ApplicationUserId = ApplicationUserId.Value;
            await mediator.Send(changePassowrdCommand);
            return NoContent();
        }

        [HttpPost]
        [Route("change-email")]
        [RequiredRoles(ApplicationUserRole.Admin, ApplicationUserRole.OrderHandler, ApplicationUserRole.Customer)]
        public async Task<IActionResult> ChangeEmail([FromBody] ChangeEmailCommand changeEmailCommand)
        {
            changeEmailCommand.ApplicationUserId = ApplicationUserId.Value;
            await mediator.Send(changeEmailCommand);
            return NoContent();
        }

        [HttpPost]
        [Route("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordCommand resetPasswordCommand)
        {
            await mediator.Send(resetPasswordCommand);
            return NoContent();
        }

        [HttpPost]
        [Route("set-password")]
        public async Task<IActionResult> SetPassword([FromBody] SetPasswordCommand setPasswordCommand)
        {
            await mediator.Send(setPasswordCommand);
            return NoContent();
        }
    }
}
