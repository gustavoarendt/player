using Microsoft.Extensions.DependencyInjection;
using PlayerControl.Application.Events;
using PlayerControl.Application.Interfaces;
using PlayerControl.Domain.Commons;
using PlayerControl.Domain.Repositories;
using PlayerControl.Infrastructure.Data.EntityFramework.Categories;
using PlayerControl.Infrastructure.Data.EntityFramework.Context;
using PlayerControl.Infrastructure.Data.EntityFramework.Genres;
using PlayerControl.Infrastructure.Data.EntityFramework.Videos;
using PlayerControl.Infrastructure.Data.Storage;

namespace PlayerControl.Infrastructure.CrossCutting.IoC
{
    public static class RepositoryDependency
    {
        public static void AddRepositoryDependency(this IServiceCollection services)
        {
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IVideoRepository, VideoRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IStoreService, StoreService>();

            services.AddScoped<IDomainEventPublisher, DomainEventPublisher>();
        }
    }
}
