using PlayerControl.Application.UseCases.Genres.Interfaces;
using PlayerControl.Application.UseCases.Genres.Models;
using PlayerControl.Application.UseCases.Genres.Queries;
using PlayerControl.Domain.Repositories;

namespace PlayerControl.Application.UseCases.Genres.Handlers
{
    public class GetListQueryHandler : IGetList
    {
        private readonly IGenreRepository _genreRepository;

        public GetListQueryHandler(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<IReadOnlyCollection<GenreViewModel>> Handle(GetListQuery request, CancellationToken cancellationToken)
        {
            var genreList = await _genreRepository.List();
            return ListGenreViewModel.FromEntityList(genreList);
        }
    }
}
