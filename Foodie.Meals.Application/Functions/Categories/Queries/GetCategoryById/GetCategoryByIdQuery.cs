using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdQuery : IRequest<GetCategoryByIdQueryResponse>
    {
        public int Id { get; }

        public GetCategoryByIdQuery(int id)
        {
            this.Id = id;
        }
    }
}
