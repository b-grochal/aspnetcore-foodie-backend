using Foodie.Identity.Application.Functions.Admins.Commands.CreateAdmin;
using Foodie.Identity.Application.Functions.Admins.Commands.DeleteAdmin;
using Foodie.Identity.Application.Functions.Admins.Commands.UpdateAdmin;
using Foodie.Identity.Application.Functions.Admins.Queries.GetAdminById;
using Foodie.Identity.Application.Functions.Admins.Queries.GetAdmins;
using Foodie.Shared.Authorization;
using Foodie.Shared.Controllers;
using Foodie.Shared.Extensions.Attributes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Foodie.Identity.Controllers
{
    [Route("api/[controller]")]
    [Roles(RolesDictionary.Admin)]
    public class AdminsController : BaseController
    {
        public AdminsController(IMediator mediator) : base(mediator) { }

        // POST api/admins
        [HttpPost]
        public async Task<IActionResult> CreateAdmin([FromBody] CreateAdminCommand createAdminCommand)
        {
            createAdminCommand.CreatedBy = GetApplicationUserClaim(ClaimTypes.Email);
            var result = await mediator.Send(createAdminCommand);
            return Ok(result);
        }

        // PUT api/admins/5
        [HttpPut("{adminId}")]
        public async Task<IActionResult> UpdateAdmin(string adminId, [FromBody] UpdateAdminCommand updateAdminCommand)
        {
            if (adminId != updateAdminCommand.Id)
            {
                return BadRequest();
            }

            updateAdminCommand.LastModifiedBy = GetApplicationUserClaim(ClaimTypes.Email);
            var result = await mediator.Send(updateAdminCommand);
            return Ok(result);
        }

        // DELETE api/admins/5
        [HttpDelete("{adminId}")]
        public async Task<IActionResult> DeleteAdmin(string adminId)
        {
            var command = new DeleteAdminCommand(adminId);
            var result = await mediator.Send(command);
            return Ok(result);
        }

        // GET api/admins/5
        [HttpGet("{adminId}")]
        public async Task<IActionResult> GetAdmin(string adminId)
        {
            var query = new GetAdminByIdQuery(adminId);
            var result = await mediator.Send(query);
            return Ok(result);
        }

        // GET api/admins
        [HttpGet]
        public async Task<IActionResult> GetAdmins([FromQuery] GetAdminsQuery getAdminsQuery)
        {
            var result = await mediator.Send(getAdminsQuery);
            return Ok(result);
        }
    }
}
