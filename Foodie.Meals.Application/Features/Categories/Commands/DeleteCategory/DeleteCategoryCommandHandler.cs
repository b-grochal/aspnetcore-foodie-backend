using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Common.Results;
using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using Foodie.Meals.Application.Features.Categories.Errors;
using Foodie.Meals.Domain.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Features.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Result<DeleteCategoryCommandResponse>>
    {
        private readonly ICategoriesRepository _categoriesRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCategoryCommandHandler(ICategoriesRepository categoriesRepository, IUnitOfWork unitOfWork)
        {
            _categoriesRepository = categoriesRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<DeleteCategoryCommandResponse>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryToDelete = await _categoriesRepository.GetByIdAsync(request.Id);

            if (categoryToDelete is null)
                return Result.Failure<DeleteCategoryCommandResponse>(CategoryErrors.CategoryNotFoundById(request.Id));

            await _categoriesRepository.DeleteAsync(categoryToDelete);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new DeleteCategoryCommandResponse
            {
                Id = request.Id
            };
        }
    }
}
