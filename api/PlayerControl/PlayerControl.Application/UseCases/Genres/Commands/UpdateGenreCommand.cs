using MediatR;
using PlayerControl.Application.UseCases.Genres.Models;

namespace PlayerControl.Application.UseCases.Genres.Commands
{
    public record UpdateGenreCommand(Guid Id,  string? Name, bool? IsActive, List<Guid>? CategoryIds = null) : IRequest<GenreViewModel>
    {
    }
}
