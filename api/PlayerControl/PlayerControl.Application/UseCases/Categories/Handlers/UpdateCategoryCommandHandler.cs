using PlayerControl.Application.Exceptions;
using PlayerControl.Application.Interfaces;
using PlayerControl.Application.UseCases.Categories.Commands;
using PlayerControl.Application.UseCases.Categories.Interfaces;
using PlayerControl.Application.UseCases.Categories.Models;
using PlayerControl.Domain.Repositories;

namespace PlayerControl.Application.UseCases.Categories.Handlers
{
    public class UpdateCategoryCommandHandler : IUpdateCategory
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CategoryResponseViewModel> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetById(request.Id);
            category.UpdateData(request.Name, request.Description);
            if (request.IsActive is not null && request.IsActive != category.IsActive)
                if ((bool)request.IsActive) category.Activate();
                else category.Deactivate();

            await _categoryRepository.Update(category);
            await _unitOfWork.Commit();

            return CategoryResponseViewModel.FromEntity(category);
        }
    }
}
