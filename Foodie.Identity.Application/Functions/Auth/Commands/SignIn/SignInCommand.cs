using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.Auth.Commands.SignIn
{
    public class SignInCommand : IRequest<SignInCommandResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
