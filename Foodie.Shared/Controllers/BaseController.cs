using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Foodie.Shared.Controllers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected readonly IMediator mediator;

        protected BaseController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        protected string GetApplicationUserClaim(string claimName)
        {
            return this.User.Claims.FirstOrDefault(c => c.Type == claimName)?.Value;
        }
    }
}
