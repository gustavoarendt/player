using PlayerControl.Application.Interfaces;
using PlayerControl.Application.UseCases.Videos.Commands;
using PlayerControl.Application.UseCases.Videos.Interfaces;
using PlayerControl.Application.UseCases.Videos.Models;
using PlayerControl.Domain.Entities.Videos;
using PlayerControl.Domain.Repositories;
using PlayerControl.Domain.Validations;

namespace PlayerControl.Application.UseCases.Videos.Handlers
{
    public class CreateVideoCommandHandler : ICreateVideo
    {
        private readonly IVideoRepository _videoRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICategoryRepository _categoryRepository;

        public CreateVideoCommandHandler(
            IVideoRepository videoRepository,
            IUnitOfWork unitOfWork,
            ICategoryRepository categoryRepository)
        {
            _videoRepository = videoRepository;
            _unitOfWork = unitOfWork;
            _categoryRepository = categoryRepository;
        }

        public async Task<VideoViewModel> Handle(CreateVideoCommand request, CancellationToken cancellationToken)
        {
            var video = new Video(request.Title, request.Description, request.Year, request.Duration, request.Rating);

            var validationHandler = new NotificationValidationHandler();
            video.Validate(validationHandler);
            if (validationHandler.HasErrors()) throw new EntityValidationException("There are validation errors", validationHandler.Errors);

            if (request.CategoryIds is not null && request.CategoryIds.Any())
                foreach (var categoryId in request.CategoryIds) video.AddCategory(categoryId);

            await _videoRepository.Insert(video);
            await _unitOfWork.Commit();

            return VideoViewModel.FromEntity(video);
        }
    }
}
