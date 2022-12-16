using AutoMapper;
using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

            return new GetCategoriesQueryResponse
            {
                TotalCount = categories.TotalCount,
                PageSize = categories.PageSize,
                CurrentPage = categories.CurrentPage,
                TotalPages = (int)Math.Ceiling(categories.TotalCount / (double)categories.PageSize),
                Categories = mapper.Map<IEnumerable<CategoryDto>>(categories),
                Name = request.Name,
            };
        }
    }
}
