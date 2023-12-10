using MediatR;
using PlayerControl.Application.UseCases.Videos.Models;

namespace PlayerControl.Application.UseCases.Videos.Commands
{
    public record UploadMediaCommand(Guid VideoId, FileInputModel VideoFile) : IRequest
    {
    }
}
