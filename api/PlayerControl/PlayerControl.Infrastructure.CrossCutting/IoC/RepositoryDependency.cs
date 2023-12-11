using Microsoft.Extensions.DependencyInjection;
using PlayerControl.Domain.Repositories;
using PlayerControl.Infrastructure.Data.EntityFramework.Categories;
using PlayerControl.Infrastructure.Data.EntityFramework.Genres;
using PlayerControl.Infrastructure.Data.EntityFramework.Videos;

namespace PlayerControl.Infrastructure.CrossCutting.IoC
{
    public static class RepositoryDependency
    {
        public static void AddRepositoryDependency(this IServiceCollection services)
        {
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IVideoRepository, VideoRepository>();
        }
    }
}
