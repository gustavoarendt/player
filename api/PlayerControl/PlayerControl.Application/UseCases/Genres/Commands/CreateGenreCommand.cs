using MediatR;
using PlayerControl.Application.UseCases.Genres.Models;

namespace PlayerControl.Application.UseCases.Genres.Commands
{
    public record CreateGenreCommand(string Name, List<Guid>? CategoryIds = null) : IRequest<GenreViewModel>
    {
    }
}
