﻿using AutoMapper;
using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using Foodie.Meals.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, GetCategoryByIdQueryResponse>
    {
        private readonly ICategoriesRepository categoriesRepository;
        private readonly IMapper mapper;

        public GetCategoryByIdQueryHandler(ICategoriesRepository categoriesRepository, IMapper mapper)
        {
            this.categoriesRepository = categoriesRepository;
            this.mapper = mapper;
        }

        public async Task<GetCategoryByIdQueryResponse> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await categoriesRepository.GetByIdAsync(request.Id);

            if (category == null)
                throw new CategoryNotFoundException(request.Id);

            return mapper.Map<GetCategoryByIdQueryResponse>(category);
        }
    }
}
