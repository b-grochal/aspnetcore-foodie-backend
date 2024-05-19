using Foodie.Common.Api.Authorization;
using Foodie.Common.Api.Controllers;
using Foodie.Common.Api.Results;
using Foodie.Common.Enums;
using Foodie.Common.Results;
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

            return result.Match(
                onSuccess: Ok,
                onFailure: HandleFailure);
        }

        [HttpGet]
        [RequiredRoles(ApplicationUserRole.Admin, ApplicationUserRole.OrderHandler, ApplicationUserRole.Customer)]
        public async Task<IActionResult> GetAccountData()
        {
            var result = await mediator.Send(new GetAccountDataQuery());

            return result.Match(
                onSuccess: () => Ok(result.Value),
                onFailure: HandleFailure);
        }

        [HttpPut]
        [RequiredRoles(ApplicationUserRole.Admin, ApplicationUserRole.OrderHandler, ApplicationUserRole.Customer)]
        public async Task<IActionResult> UpdateAccountData([FromBody] UpdateAccountDataCommand updateAccountDataCommand)
        {
            var result = await mediator.Send(updateAccountDataCommand);

            return result.Match(
                onSuccess: NoContent,
                onFailure: HandleFailure);
        }

        [HttpPost]
        [Route("change-password")]
        [RequiredRoles(ApplicationUserRole.Admin, ApplicationUserRole.OrderHandler, ApplicationUserRole.Customer)]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordCommand changePassowrdCommand)
        {
            var result = await mediator.Send(changePassowrdCommand);

            return result.Match(
                onSuccess: NoContent,
                onFailure: HandleFailure);
        }

        [HttpPost]
        [Route("change-email")]
        [RequiredRoles(ApplicationUserRole.Admin, ApplicationUserRole.OrderHandler, ApplicationUserRole.Customer)]
        public async Task<IActionResult> ChangeEmail([FromBody] ChangeEmailCommand changeEmailCommand)
        {
            var result = await mediator.Send(changeEmailCommand);

            return result.Match(
                onSuccess: NoContent,
                onFailure: HandleFailure);
        }

        [HttpPost]
        [Route("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordCommand resetPasswordCommand)
        {
            var result = await mediator.Send(resetPasswordCommand);
            
            return result.Match(
                onSuccess: NoContent,
                onFailure: HandleFailure);
        }

        [HttpPost]
        [Route("set-password")]
        public async Task<IActionResult> SetPassword([FromBody] SetPasswordCommand setPasswordCommand)
        {
            var result = await mediator.Send(setPasswordCommand);
            
            return result.Match(
                onSuccess: NoContent,
                onFailure: HandleFailure);
        }
    }
}
