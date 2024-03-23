using Foodie.Common.Enums;
using Foodie.Common.Infrastructure.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Foodie.Common.Api.Controllers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected readonly IMediator mediator;

        protected BaseController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        protected ApplicationUserRole? Role =>
            Enum.TryParse<ApplicationUserRole>(User.Claims.FirstOrDefault(c => c.Type == ApplicationUserClaim.Role).Value, out var role) ? role : null;

        protected int? LocationId =>
            int.TryParse(User.Claims.FirstOrDefault(c => c.Type == ApplicationUserClaim.LocationId).Value, out var locationId) ? locationId : null;

        protected string Email =>
            User.Claims.FirstOrDefault(c => c.Type == ApplicationUserClaim.Email).Value;

        protected int? ApplicationUserId =>
            int.TryParse(User.Claims.FirstOrDefault(c => c.Type == ApplicationUserClaim.Id).Value, out var applicationUserId) ? applicationUserId : null;
    }
}
