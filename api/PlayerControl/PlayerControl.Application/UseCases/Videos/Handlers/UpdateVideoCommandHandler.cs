using PlayerControl.Application.Exceptions;
using PlayerControl.Application.Interfaces;
using PlayerControl.Application.UseCases.Videos.Commands;
using PlayerControl.Application.UseCases.Videos.Interfaces;
using PlayerControl.Application.UseCases.Videos.Models;
using PlayerControl.Domain.Entities.Videos;
using PlayerControl.Domain.Repositories;
using PlayerControl.Domain.Validations;

namespace PlayerControl.Application.UseCases.Videos.Handlers
{
    public class UpdateVideoCommandHandler : IUpdateVideo
    {
        private readonly IVideoRepository _videoRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStoreService _storeService;

        public UpdateVideoCommandHandler(
            IVideoRepository videoRepository,
            IGenreRepository genreRepository,
            ICategoryRepository categoryRepository,
            IUnitOfWork unitOfWork,
            IStoreService storeService)
        {
            _videoRepository = videoRepository;
            _genreRepository = genreRepository;
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
            _storeService = storeService;
        }

        public async Task<VideoViewModel> Handle(UpdateVideoCommand request, CancellationToken cancellationToken)
        {
            var video = await _videoRepository.GetById(request.Id);

            video.UpdateData(request.Title, request.Description, request.Year, request.Duration, request.Rating);
            var validationHandler = new NotificationValidationHandler();
            video.Validate(validationHandler);
            if (validationHandler.HasErrors()) throw new EntityValidationException("There are validation errors", validationHandler.Errors);
            await AddRelationsAndImage(request, video);
            try
            {
                await UploadImage(request, video);
                await UploadMedia(request, video);
                await _videoRepository.Insert(video);
                await _unitOfWork.Commit();
            }
            catch (Exception)
            {
                if (video.Image is not null) await _storeService.Delete(video.Image.Path);
                throw;
            }

            return VideoViewModel.FromEntity(video);
        }

        private async Task UploadImage(UpdateVideoCommand request, Video video)
        {
            if (request.Image is not null)
            {
                var imagePath = await _storeService.Upload($"{video.Id}-image.{request.Image.Extension}", request.Image.FileStream);
                video.UpdateImage(imagePath);
            }
        }

        private async Task UploadMedia(UpdateVideoCommand request, Video video)
        {
            if (request.Media is not null)
            {
                var mediaPath = await _storeService.Upload($"{video.Id}-media.{request.Media.Extension}", request.Media.FileStream);
                video.UpdateMedia(mediaPath);
            }
        }

        private async Task AddRelationsAndImage(UpdateVideoCommand request, Video video)
        {
            if (request.CategoryIds is not null && request.CategoryIds.Any())
            {
                await ValidateCategoryIds(request);
                request.CategoryIds.ToList().ForEach(video.AddCategory);
            }

            if (request.GenreIds is not null && request.GenreIds.Any())
            {
                await ValidateGenreIds(request);
                request.GenreIds.ToList().ForEach(video.AddGenre);
            }
        }

        private async Task ValidateGenreIds(UpdateVideoCommand request)
        {
            var dbGenres = await _genreRepository.GetIdListByIds(request.GenreIds!.ToList());
            if (dbGenres.Count() < request.GenreIds!.Count)
            {
                var notFound = request.GenreIds.ToList().FindAll(genreId => !dbGenres.Contains(genreId));
                if (notFound.Any())
                {
                    var notFoundItems = String.Join(", ", notFound);
                    throw new NotFoundException($"The Following Ids could not be found: {notFoundItems}");
                }
            }
        }

        private async Task ValidateCategoryIds(UpdateVideoCommand request)
        {
            var dbCategories = await _categoryRepository.GetIdListByIds(request.CategoryIds!.ToList());
            if (dbCategories.Count() < request.CategoryIds!.Count)
            {
                var notFound = request.CategoryIds.ToList().FindAll(categoryId => !dbCategories.Contains(categoryId));
                if (notFound.Any())
                {
                    var notFoundItems = String.Join(", ", notFound);
                    throw new NotFoundException($"The Following Ids could not be found: {notFoundItems}");
                }
            }
        }
    }
}
