using MediatR;
using PlayerControl.Application.UseCases.Genres.Commands;

namespace PlayerControl.Application.UseCases.Genres.Interfaces
{
    public interface IDeleteGenre : IRequestHandler<DeleteGenreCommand, Task>
    {
    }
}
