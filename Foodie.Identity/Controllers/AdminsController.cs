using Foodie.Identity.Application.Functions.Admins.Commands.CreateAdmin;
using Foodie.Identity.Application.Functions.Admins.Commands.DeleteAdmin;
using Foodie.Identity.Application.Functions.Admins.Commands.UpdateAdmin;
using Foodie.Identity.Application.Functions.Admins.Queries.GetAdminById;
using Foodie.Identity.Application.Functions.Admins.Queries.GetAdmins;
using Foodie.Shared.Attributes;
using Foodie.Shared.Controllers;
using Foodie.Shared.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Foodie.Identity.Controllers
{
    [Route("api/[controller]")]
    [RequiredRoles(ApplicationUserRole.Admin)]
    public class AdminsController : BaseController
    {
        public AdminsController(IMediator mediator) : base(mediator) { }

        // POST api/admins
        [HttpPost]
        public async Task<IActionResult> CreateAdmin([FromBody] CreateAdminCommand createAdminCommand)
        {
            createAdminCommand.CreatedBy = Email;
            var result = await mediator.Send(createAdminCommand);
            return Ok(result);
        }

        // PUT api/admins/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAdmin(int id, [FromBody] UpdateAdminCommand updateAdminCommand)
        {
            if (id != updateAdminCommand.Id)
            {
                return BadRequest();
            }

            updateAdminCommand.LastModifiedBy = Email;
            var result = await mediator.Send(updateAdminCommand);
            return Ok(result);
        }

        // DELETE api/admins/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdmin(int id)
        {
            var command = new DeleteAdminCommand(id);
            var result = await mediator.Send(command);
            return Ok(result);
        }

        // GET api/admins/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdmin(int id)
        {
            var query = new GetAdminByIdQuery(id);
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
