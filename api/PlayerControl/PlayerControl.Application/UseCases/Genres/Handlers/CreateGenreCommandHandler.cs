﻿using PlayerControl.Application.Exceptions;
using PlayerControl.Application.Interfaces;
using PlayerControl.Application.UseCases.Genres.Commands;
using PlayerControl.Application.UseCases.Genres.Interfaces;
using PlayerControl.Application.UseCases.Genres.Models;
using PlayerControl.Domain.Entities.Genres;
using PlayerControl.Domain.Repositories;

namespace PlayerControl.Application.UseCases.Genres.Handlers
{
    public class CreateGenreCommandHandler : ICreateGenre
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICategoryRepository _categoryRepository;

        public CreateGenreCommandHandler(IGenreRepository genreRepository, IUnitOfWork unitOfWork, ICategoryRepository categoryRepository)
        {
            _genreRepository = genreRepository;
            _unitOfWork = unitOfWork;
            _categoryRepository = categoryRepository;
        }

        public async Task<GenreViewModel> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = new Genre(request.Name);
            if (request.CategoryIds is not null && request.CategoryIds.Any())
            {
                await ValidateCategoryIds(request);
                request.CategoryIds.ForEach(id => genre.AddCategoryId(id));
            }
            await _genreRepository.Insert(genre);
            await _unitOfWork.Commit();

            return GenreViewModel.FromEntity(genre);
        }

        private async Task ValidateCategoryIds(CreateGenreCommand request)
        {
            if (request.CategoryIds is not null && request.CategoryIds.Any())
            {
                var dbCategories = await _categoryRepository.GetIdListByIds(request.CategoryIds.ToList());
                if (dbCategories.Count() < request.CategoryIds.Count)
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
}
