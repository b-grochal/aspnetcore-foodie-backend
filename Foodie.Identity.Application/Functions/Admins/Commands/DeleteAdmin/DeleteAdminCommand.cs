using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.Admins.Commands.DeleteAdmin
{
    public class DeleteAdminCommand : IRequest<DeleteAdminCommandResponse>
    {
        public string AdminId { get; set; }

        public DeleteAdminCommand(string adminId)
        {
            this.AdminId = adminId;
        }
    }
}
