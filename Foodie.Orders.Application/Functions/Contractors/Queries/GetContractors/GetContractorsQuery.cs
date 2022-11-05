using Foodie.Shared.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Functions.Contractors.Queries.GetContractors
{
    public class GetContractorsQuery : PagedQuery, IRequest<GetContractorsQueryResponse>
    {
        public int RestaurantId { get; set; }
        public int LocationId { get; set; }
        public int CityId { get; set; }
    }
}
