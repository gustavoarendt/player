using PlayerControl.Application.Exceptions;
using PlayerControl.Application.Interfaces;
using PlayerControl.Application.UseCases.Categories.Common;
using PlayerControl.Domain.Repositories;

namespace PlayerControl.Application.UseCases.Categories.Update
{
    public class UpdateCategory : IUpdateCategory
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCategory(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CategoryResponseModel> Handle(UpdateCategoryRequest request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetById(request.Id);
            if (category is null)
            {
                throw new NotFoundException($"{nameof(category)} with Id: {request.Id} could not be found");
            }
            category.UpdateData(request.Name, request.Description);
            if (request.IsActive is not null && request.IsActive != category.IsActive)
                if ((bool) request.IsActive) category.Activate();
                else category.Deactivate();
            
            await _categoryRepository.Update(category);
            await _unitOfWork.Commit();

            return CategoryResponseModel.FromEntity(category);
        }
    }
}
