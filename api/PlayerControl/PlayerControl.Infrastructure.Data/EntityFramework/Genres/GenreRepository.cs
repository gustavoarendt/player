﻿using Microsoft.EntityFrameworkCore;
using PlayerControl.Application.Exceptions;
using PlayerControl.Domain.Commons;
using PlayerControl.Domain.Entities.Genres;
using PlayerControl.Domain.Repositories;
using PlayerControl.Infrastructure.Data.EntityFramework.Context;

namespace PlayerControl.Infrastructure.Data.EntityFramework.Genres
{
    public class GenreRepository : RepositoryBase<Genre>, IGenreRepository
    {
        readonly DbSet<Genre> _genres;
        readonly DbSet<GenreCategory> _genresCategories;

        public GenreRepository(EntityFrameworkDbContext context) : base(context)
        {
            _genres = context.Set<Genre>();
            _genresCategories = context.Set<GenreCategory>();
        }

        public async Task<IEnumerable<Genre>> List()
        {
            var genres = await _genres.AsNoTracking().Where(c => c.IsActive).ToListAsync();
            foreach (var genre in genres)
            {
                var genreCategories = _genresCategories.Where(gc => gc.GenreId == genre.Id).ToList();

                genre.UpdateGenresCategories(genreCategories);
            }
            return genres;
        }

        public override async Task<Genre> GetById(Guid id)
        {
            var genre = await _genres.FirstOrDefaultAsync(g => g.Id == id);
            if (genre == null)
            {
                throw new NotFoundException($"{nameof(Entity)} of Id: {id} could not be found");
            }
            var genreCategories = await _genresCategories.Where(gc => gc.GenreId == genre.Id).Select(gc => gc.CategoryId).ToListAsync();
            genreCategories.ForEach(genre.AddCategoryId);
            return genre;
        }

        public override async Task Insert(Genre genre)
        {
            await _genres.AddAsync(genre);
            if (genre.CategoryIds.Any())
            {
                var relations = genre.CategoryIds.Select(categoryId => new GenreCategory(genre.Id, categoryId));
                _genresCategories.AddRange(relations);
            }
        }

        public override async Task Update(Genre genre)
        {
            _genres.Update(genre);
            _genresCategories.RemoveRange(_genresCategories.Where(gc => gc.GenreId == genre.Id));
            if (genre.CategoryIds.Any())
            {
                var relations = genre.CategoryIds.Select(categoryId => new GenreCategory(genre.Id, categoryId));
                await _genresCategories.AddRangeAsync(relations);
            }
        }

        public override Task Remove(Genre genre)
        {
            _genresCategories.RemoveRange(_genresCategories.Where(gc => gc.GenreId == genre.Id));
            _genres.Remove(genre);
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Guid>> GetIdListByIds(ICollection<Guid> ids)
        {
            return await Task.FromResult(_genres.AsQueryable().AsNoTracking().Where(c => ids.Contains(c.Id)).Select(x => x.Id));
        }
    }
}
