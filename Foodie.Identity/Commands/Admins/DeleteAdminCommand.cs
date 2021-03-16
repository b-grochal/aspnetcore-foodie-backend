using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.Identity.Commands.Admins
{
    public class DeleteAdminCommand : IRequest
    {
        public string Id { get; set; }

        public DeleteAdminCommand(string id)
        {
            this.Id = id;
        }
    }
}
