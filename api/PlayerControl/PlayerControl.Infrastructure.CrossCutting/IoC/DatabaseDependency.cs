using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PlayerControl.Infrastructure.Data.EntityFramework.Context;

namespace PlayerControl.Infrastructure.CrossCutting.IoC
{
    public static class DatabaseDependency
    {
        public static IServiceCollection AddDatabaseDependency(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<EntityFrameworkDbContext>(options => _ = options.UseNpgsql(connectionString));
            return services;
        }
    }
}
