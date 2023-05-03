using AutoMapper;
using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Categories.Queries.GetCategories
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, GetCategoriesQueryResponse>
    {
        private readonly ICategoriesRepository categoriesRepository;
        private readonly IMapper mapper;

        public GetCategoriesQueryHandler(ICategoriesRepository categoriesRepository, IMapper mapper)
        {
            this.categoriesRepository = categoriesRepository;
            this.mapper = mapper;
        }

        public async Task<GetCategoriesQueryResponse> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await categoriesRepository.GetAllAsync(request.PageNumber, request.PageSize, request.Name);
            var categoriesCount = categories.Count();

            return new GetCategoriesQueryResponse
            {
                TotalCount = categoriesCount,
                PageSize = request.PageSize,
                CurrentPage = request.PageNumber,
                TotalPages = (int)Math.Ceiling(categoriesCount / (double)request.PageSize),
                Categories = mapper.Map<IEnumerable<CategoryDto>>(categories),
                Name = request.Name,
            };
        }
    }
}
