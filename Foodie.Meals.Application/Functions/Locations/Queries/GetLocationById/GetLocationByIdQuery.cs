using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Locations.Queries.GetLocationById
{
    public class GetLocationByIdQuery : IRequest<LocationDetailsResponse>
    {
        public int LocationId { get; }

        public GetLocationByIdQuery(int locationId)
        {
            this.LocationId = locationId;
        }
    }
}
