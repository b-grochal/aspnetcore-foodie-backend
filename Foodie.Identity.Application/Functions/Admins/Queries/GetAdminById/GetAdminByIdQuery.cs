using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.Admins.Queries.GetAdminById
{
    public class GetAdminByIdQuery : IRequest<GetAdminByIdQueryResponse>
    {
        public string AdminId { get; }

        public GetAdminByIdQuery(string adminId)
        {
            this.AdminId = adminId;
        }
    }
}
