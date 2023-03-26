using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Restaurants.Queries.GetRestaurantById
{
    public class GetRestaurantByIdQuery : IRequest<GetRestaurantByIdQueryResponse>
    {
        public int Id { get; }

        public GetRestaurantByIdQuery(int id)
        {
            this.Id = id;
        }
    }
}
