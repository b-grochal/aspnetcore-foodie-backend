﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Meals.Queries.GetMealById
{
    public class GetMealByIdQuery : IRequest<GetMealByIdQueryResponse>
    {
        public int Id { get; }

        public GetMealByIdQuery(int id)
        {
            this.Id = id;
        }
    }
}
