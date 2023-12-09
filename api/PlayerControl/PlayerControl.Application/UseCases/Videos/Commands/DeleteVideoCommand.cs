using MediatR;

namespace PlayerControl.Application.UseCases.Videos.Commands
{
    public record DeleteVideoCommand(Guid IdVideo) : IRequest
    {
    }
}
