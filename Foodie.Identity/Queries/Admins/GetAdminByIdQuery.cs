using Foodie.Identity.Responses.Admins;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.Identity.Queries.Admins
{
    public class GetAdminByIdQuery : IRequest<AdminResponse>
    {
        public string Id { get; set; }

        public GetAdminByIdQuery(string id)
        {
            this.Id = id;
        }
    }
}
