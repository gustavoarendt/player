using Microsoft.EntityFrameworkCore;
using PlayerControl.Domain.Genres;
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
            return await Task.FromResult(_genres.AsQueryable().AsNoTracking().Where(c => c.IsActive));
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
    }
}
