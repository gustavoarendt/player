using Microsoft.Extensions.DependencyInjection;
using PlayerControl.Application.Interfaces;
using PlayerControl.Domain.Repositories;
using PlayerControl.Infrastructure.Data.EntityFramework.Categories;
using PlayerControl.Infrastructure.Data.EntityFramework.Context;
using PlayerControl.Infrastructure.Data.EntityFramework.Genres;

namespace PlayerControl.Infrastructure.CrossCutting.IoC
{
    public static class RepositoryDependency
    {
        public static void AddRepositoryDependency(this IServiceCollection services)
        {
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
