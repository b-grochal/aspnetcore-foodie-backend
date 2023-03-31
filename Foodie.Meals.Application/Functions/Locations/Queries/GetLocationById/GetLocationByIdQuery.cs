using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Locations.Queries.GetLocationById
{
    public class GetLocationByIdQuery : IRequest<GetLocationByIdQueryResponse>
    {
        public int Id { get; }

        public GetLocationByIdQuery(int id)
        {
            this.Id = id;
        }
    }
}
