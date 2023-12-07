using MediatR;

namespace PlayerControl.Application.UseCases.Genres.Commands
{
    public record DeleteGenreCommand(Guid Id) : IRequest<Task>
    {
    }
}
