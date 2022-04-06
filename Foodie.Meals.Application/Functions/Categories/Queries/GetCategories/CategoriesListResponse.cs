using Foodie.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Categories.Queries.GetCategories
{
    public class CategoriesListResponse : PagedResponse
    {
        public IEnumerable<CategoryResponse> Categories { get; set; }
        public string Name { get; set; }
    }
}
