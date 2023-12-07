using PlayerControl.Application.Exceptions;
using PlayerControl.Application.Interfaces;
using PlayerControl.Application.UseCases.Categories.Commands;
using PlayerControl.Application.UseCases.Categories.Interfaces;
using PlayerControl.Application.UseCases.Categories.Models;
using PlayerControl.Domain.Repositories;

namespace PlayerControl.Application.UseCases.Categories.Handlers
{
    public class DeleteCategoryCommandHandler : IDeleteCategory
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CategoryResponseViewModel> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetById(request.Id);
            await _categoryRepository.Remove(category);
            await _unitOfWork.Commit();

            return CategoryResponseViewModel.FromEntity(category);
        }
    }
}
