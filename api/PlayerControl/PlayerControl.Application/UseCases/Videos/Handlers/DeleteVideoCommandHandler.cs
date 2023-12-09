using MediatR;
using PlayerControl.Application.Interfaces;
using PlayerControl.Application.UseCases.Videos.Commands;
using PlayerControl.Application.UseCases.Videos.Interfaces;
using PlayerControl.Domain.Repositories;

namespace PlayerControl.Application.UseCases.Videos.Handlers
{
    public class DeleteVideoCommandHandler : IDeleteVideo
    {
        private readonly IVideoRepository _videoRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStoreService _storeService;

        public DeleteVideoCommandHandler(
            IVideoRepository videoRepository,
            IUnitOfWork unitOfWork,
            IStoreService storeService)
        {
            _videoRepository = videoRepository;
            _unitOfWork = unitOfWork;
            _storeService = storeService;
        }

        public async Task<Unit> Handle(DeleteVideoCommand request, CancellationToken cancellationToken)
        {
            var video = await _videoRepository.GetById(request.IdVideo);
            await _videoRepository.Remove(video);
            await _unitOfWork.Commit();

            if (video.Media is not null) await _storeService.Delete(video.Media.FilePath);

            return Unit.Value;
        }
    }
}
