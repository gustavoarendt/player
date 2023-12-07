using MediatR;
using PlayerControl.Application.UseCases.Genres.Commands;
using PlayerControl.Application.UseCases.Genres.Models;

namespace PlayerControl.Application.UseCases.Genres.Interfaces
{
    public interface IUpdateGenre : IRequestHandler<UpdateGenreCommand, GenreViewModel>
    {
    }
}
