using MediatR;
using PlayerControl.Application.UseCases.Genres.Models;

namespace PlayerControl.Application.UseCases.Genres.Queries
{
    public record GetGenreQuery(Guid Id) : IRequest<GenreViewModel>
    {
    }
}
