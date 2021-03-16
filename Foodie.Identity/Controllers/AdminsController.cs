using Foodie.Identity.Commands.Admins;
using Foodie.Identity.Queries.Admins;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly IMediator mediator;

        public AdminsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // POST api/Admins
        [HttpPost]
        public async Task<IActionResult> CreateAdmin([FromBody] CreateAdminCommand createAdminCommand)
        {
            await mediator.Send(createAdminCommand);
            return Ok();
        }

        // PUT api/Admin/5
        [HttpPut("{adminId}")]
        public async Task<IActionResult> EditAdmin(string adminId, [FromBody] EditAdminCommand editAdminCommand)
        {
            if (adminId != editAdminCommand.Id)
            {
                return BadRequest();
            }

            await mediator.Send(editAdminCommand);
            return Ok();
        }

        // DELETE api/Admins/5
        [HttpDelete("{adminId}")]
        public async Task<IActionResult> DeleteAdmin(string adminId)
        {
            var command = new DeleteAdminCommand(adminId);
            await mediator.Send(command);
            return Ok();
        }

        // GET api/Admins/5
        [HttpGet("{adminId}")]
        public async Task<IActionResult> GetAdmin(string adimnId)
        {
            var query = new GetAdminByIdQuery(adimnId);
            var result = await mediator.Send(query);
            return Ok(result);
        }

        // GET api/Admins
        [HttpGet]
        public async Task<IActionResult> GetAllAdmins()
        {
            var query = new GetAllAdminsQuery();
            var result = await mediator.Send(query);
            return Ok(result);
        }
    }
}
