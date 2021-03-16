using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.Identity.Commands.Users
{
    public class DeleteUserCommand : IRequest
    {
        public string Id { get; set; }

        public DeleteUserCommand(string id)
        {
            this.Id = id;
        }
    }
}
