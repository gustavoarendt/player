using MediatR;
using PlayerControl.Application.UseCases.Genres.Models;
using PlayerControl.Application.UseCases.Genres.Queries;

namespace PlayerControl.Application.UseCases.Genres.Interfaces
{
    public interface IGetGenre : IRequestHandler<GetGenreQuery, GenreViewModel>
    {
    }
}
