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

namespace Foodie.Meals.Application.Functions.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, DeleteCategoryCommandResponse>
    {
        private readonly ICategoriesRepository categoriesRepository;

        public DeleteCategoryCommandHandler(ICategoriesRepository categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        public async Task<DeleteCategoryCommandResponse> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryToDelete = await categoriesRepository.GetByIdAsync(request.Id);

            if (categoryToDelete == null)
                throw new CategoryNotFoundException(request.Id);

            await categoriesRepository.DeleteAsync(categoryToDelete);

            return new DeleteCategoryCommandResponse 
            { 
                Id = request.Id 
            };
        }
    }
}
