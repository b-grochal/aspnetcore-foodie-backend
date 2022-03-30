using AutoMapper;
using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using Foodie.Meals.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly ICategoriesRepository categoriesRepository;

        public DeleteCategoryCommandHandler(ICategoriesRepository categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryToDelete = await categoriesRepository.GetByIdAsync(request.CategoryId);

            if (categoryToDelete == null)
                throw new CategoryNotFoundException(request.CategoryId);

            await categoriesRepository.DeleteAsync(categoryToDelete);
            return new Unit();
        }
    }
}
