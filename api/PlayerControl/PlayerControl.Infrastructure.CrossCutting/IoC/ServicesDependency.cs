using Microsoft.Extensions.DependencyInjection;
using PlayerControl.Application.Events.Handlers;
using PlayerControl.Application.Events;
using PlayerControl.Application.Interfaces;
using PlayerControl.Domain.Commons;
using PlayerControl.Domain.Events;
using PlayerControl.Infrastructure.Data.EntityFramework.Context;
using PlayerControl.Infrastructure.Data.Storage;

namespace PlayerControl.Infrastructure.CrossCutting.IoC
{
    public static class ServicesDependency
    {
        public static void AddServiceDependency(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IStoreService, StoreService>();

            services.AddScoped<IDomainEventPublisher, DomainEventPublisher>();
            services.AddScoped<IDomainEventHandler<VideoUploadedEvent>, SendToEncodeEventHandler>();
        }
    }
}
