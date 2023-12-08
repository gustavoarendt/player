using PlayerControl.Application.Interfaces;
using PlayerControl.Application.UseCases.Categories.Commands;
using PlayerControl.Application.UseCases.Categories.Interfaces;
using PlayerControl.Application.UseCases.Categories.Models;
using PlayerControl.Domain.Entities.Categories;
using PlayerControl.Domain.Repositories;

namespace PlayerControl.Application.UseCases.Categories.Handlers
{
    public class CreateCategoryCommandHandler : ICreateCategory
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CategoryResponseViewModel> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category(request.Name, request.Description);

            await _categoryRepository.Insert(category);
            await _unitOfWork.Commit();

            return CategoryResponseViewModel.FromEntity(category);
        }
    }
}
