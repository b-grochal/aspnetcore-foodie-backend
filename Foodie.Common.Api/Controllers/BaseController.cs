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

        protected int? ApplicationUserId =>
            int.TryParse(User.Claims.FirstOrDefault(c => c.Type == ApplicationUserClaim.Id).Value, out var applicationUserId) ? applicationUserId : null;
    }
}
