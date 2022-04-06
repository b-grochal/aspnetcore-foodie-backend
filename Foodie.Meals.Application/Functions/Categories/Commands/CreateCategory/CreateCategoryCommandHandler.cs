using AutoMapper;
using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using Foodie.Meals.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryCommandResponse>
    {
        private readonly ICategoriesRepository categoriesRepository;
        private readonly IMapper mapper;

        public CreateCategoryCommandHandler(ICategoriesRepository categoriesRepository, IMapper mapper)
        {
            this.categoriesRepository = categoriesRepository;
            this.mapper = mapper;
        }

        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = mapper.Map<Category>(request);
            await categoriesRepository.CreateAsync(category);
            return mapper.Map<CreateCategoryCommandResponse>(category);
        }
    }
}
