using PlayerControl.Application.UseCases.Genres.Interfaces;
using PlayerControl.Application.UseCases.Genres.Models;
using PlayerControl.Application.UseCases.Genres.Queries;
using PlayerControl.Domain.Repositories;

namespace PlayerControl.Application.UseCases.Genres.Handlers
{
    public class GetGenreQueryHandler : IGetGenre
    {
        private readonly IGenreRepository _genreRepository;

        public GetGenreQueryHandler(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<GenreViewModel> Handle(GetGenreQuery request, CancellationToken cancellationToken)
        {
            var genre = await _genreRepository.GetById(request.Id);
            return GenreViewModel.FromEntity(genre);
        }
    }
}
