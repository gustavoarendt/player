using PlayerControl.Application.UseCases.Genres.Interfaces;
using PlayerControl.Application.UseCases.Genres.Models;
using PlayerControl.Application.UseCases.Genres.Queries;
using PlayerControl.Domain.Repositories;

namespace PlayerControl.Application.UseCases.Genres.Handlers
{
    public class GetGenreQueryHandler : IGetGenre
    {
        private readonly IGenreRepository _genreRepository;
        private readonly ICategoryRepository _categoryRepository;

        public GetGenreQueryHandler(IGenreRepository genreRepository, ICategoryRepository categoryRepository)
        {
            _genreRepository = genreRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<GenreViewModel> Handle(GetGenreQuery request, CancellationToken cancellationToken)
        {
            var genre = await _genreRepository.GetById(request.Id);
            var categories = await _categoryRepository.List();

            foreach (var gc in genre.GenreCategories)
            {
                gc.AddCategory(categories.FirstOrDefault(c => c.Id == gc.CategoryId)!);
            }
            return GenreViewModel.FromEntity(genre);
        }
    }
}
