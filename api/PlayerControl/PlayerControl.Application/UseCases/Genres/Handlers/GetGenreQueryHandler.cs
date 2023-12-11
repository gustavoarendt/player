using PlayerControl.Application.UseCases.Genres.Interfaces;
using PlayerControl.Application.UseCases.Genres.Models;
using PlayerControl.Application.UseCases.Genres.Queries;
using PlayerControl.Domain.Entities.Genres;
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
            return GenreViewModel.FromEntity(genre);
        }
    }
}
