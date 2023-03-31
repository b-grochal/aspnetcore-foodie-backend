using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Cities.Queries.GetCityById
{
    public class GetCityByIdQuery : IRequest<GetCityByIdQueryResponse>
    {
        public int Id { get; }

        public GetCityByIdQuery(int id)
        {
            this.Id = id;
        }
    }
}
