using Foodie.Identity.Responses.Auth;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.Identity.Commands.Auth
{
    public class LoginCommand : IRequest<LoginResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
