using PlayerControl.Application.Exceptions;
using PlayerControl.Application.Interfaces;
using PlayerControl.Application.UseCases.Categories.Common;
using PlayerControl.Domain.Repositories;

namespace PlayerControl.Application.UseCases.Categories.Delete
{
    public class DeleteCategory : IDeleteCategory
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCategory(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CategoryResponseModel> Handle(DeleteCategoryRequest request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetById(request.Id);
            if (category is null)
            {
                throw new NotFoundException($"{nameof(category)} with Id: {request.Id} could not be found");
            }
            await _categoryRepository.Remove(category);
            await _unitOfWork.Commit();

            return CategoryResponseModel.FromEntity(category);
        }
    }
}
