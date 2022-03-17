﻿using Foodie.Shared.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Categories.Queries.GetCategories
{
    public class GetCategoriesQuery : PagedQuery,IRequest<CategoriesListResponse>
    {
        public string Name { get; set; }
    }
}
