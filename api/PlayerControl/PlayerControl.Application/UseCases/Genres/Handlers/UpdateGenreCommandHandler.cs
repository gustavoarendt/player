using PlayerControl.Application.Exceptions;
using PlayerControl.Application.Interfaces;
using PlayerControl.Application.UseCases.Genres.Commands;
using PlayerControl.Application.UseCases.Genres.Interfaces;
using PlayerControl.Application.UseCases.Genres.Models;
using PlayerControl.Domain.Repositories;

namespace PlayerControl.Application.UseCases.Genres.Handlers
{
    public class UpdateGenreCommandHandler : IUpdateGenre
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICategoryRepository _categoryRepository;

        public UpdateGenreCommandHandler(
            IGenreRepository genreRepository,
            IUnitOfWork unitOfWork,
            ICategoryRepository categoryRepository)
        {
            _genreRepository = genreRepository;
            _unitOfWork = unitOfWork;
            _categoryRepository = categoryRepository;
        }

        public async Task<GenreViewModel> Handle(UpdateGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = await _genreRepository.GetById(request.Id);
            genre.UpdateData(request.Name);
            if (request.IsActive is not null && request.IsActive != genre.IsActive)
                if ((bool)request.IsActive) genre.Activate();
                else genre.Deactivate();
            if (request.CategoryIds is not null && request.CategoryIds.Any())
            {
                await ValidateCategoryIds(request);
                genre.RemoveAllCategoryIds();
                request.CategoryIds.ForEach(x => genre.AddCategoryId(x));
            }

            await _genreRepository.Update(genre);
            await _unitOfWork.Commit();

            return GenreViewModel.FromEntity(genre);
        }

        private async Task ValidateCategoryIds(UpdateGenreCommand request)
        {
            var existingCategoryIds = await _categoryRepository.GetIdListByIds(request.CategoryIds!);
            var notFoundIds = request.CategoryIds!.FindAll(c => !existingCategoryIds.Contains(c));
            if (notFoundIds.Any())
            {
                var notFoundItems = String.Join(", ", notFoundIds);
                throw new NotFoundException($"The Following Ids could not be found: {notFoundItems}");
            }
        }
    }
}
