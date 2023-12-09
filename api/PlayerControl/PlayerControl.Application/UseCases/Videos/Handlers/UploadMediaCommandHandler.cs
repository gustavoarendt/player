using MediatR;
using PlayerControl.Application.Interfaces;
using PlayerControl.Application.UseCases.Videos.Commands;
using PlayerControl.Application.UseCases.Videos.Interfaces;
using PlayerControl.Domain.Entities.Videos;
using PlayerControl.Domain.Repositories;

namespace PlayerControl.Application.UseCases.Videos.Handlers
{
    public class UploadMediaCommandHandler : IUploadMedia
    {
        private readonly IVideoRepository _videoRepository;
        private readonly IStoreService _storeService;
        private readonly IUnitOfWork _unitOfWork;

        public UploadMediaCommandHandler(
            IVideoRepository videoRepository,
            IStoreService storeService,
            IUnitOfWork unitOfWork)
        {
            _videoRepository = videoRepository;
            _storeService = storeService;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UploadMediaCommand request, CancellationToken cancellationToken)
        {
            var video = await _videoRepository.GetById(request.VideoId);
            try
            {
                await UploadVideo(request, video);
                await _videoRepository.Update(video);
                await _unitOfWork.Commit();
                return Unit.Value;
            }
            catch (Exception)
            {
                if (request.VideoFile is not null && video.Media is not null) await _storeService.Delete(video.Image.Path);
                throw;
            }
        }

        private async Task UploadVideo(UploadMediaCommand request, Video video)
        {
            if (request.VideoFile != null)
            {
                var videoPath = await _storeService.Upload($"{video.Id}-video.{request.VideoFile.Extension}", request.VideoFile.FileStream);
                video.UpdateMedia(videoPath);
            }
        }
    }
}
