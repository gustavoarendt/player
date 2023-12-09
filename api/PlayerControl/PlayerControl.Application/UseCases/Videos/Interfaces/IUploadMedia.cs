using MediatR;
using PlayerControl.Application.UseCases.Videos.Commands;

namespace PlayerControl.Application.UseCases.Videos.Interfaces
{
    public interface IUploadMedia : IRequestHandler<UploadMediaCommand>
    {
    }
}
