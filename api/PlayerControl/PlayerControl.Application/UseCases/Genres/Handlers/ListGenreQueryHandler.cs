using PlayerControl.Application.UseCases.Genres.Interfaces;
using PlayerControl.Application.UseCases.Genres.Models;
using PlayerControl.Application.UseCases.Genres.Queries;
using PlayerControl.Domain.Repositories;

namespace PlayerControl.Application.UseCases.Genres.Handlers
{
    public class ListGenreQueryHandler : IListGenre
    {
        private readonly IGenreRepository _genreRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ListGenreQueryHandler(IGenreRepository genreRepository, ICategoryRepository categoryRepository)
        {
            _genreRepository = genreRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<IReadOnlyCollection<GenreViewModel>> Handle(ListGenreQuery request, CancellationToken cancellationToken)
        {
            var genres = await _genreRepository.List();

            var updatedGenres = genres.Select(genre => GenreViewModel.FromEntity(genre)).ToList();

            return updatedGenres;
        }
    }
}
