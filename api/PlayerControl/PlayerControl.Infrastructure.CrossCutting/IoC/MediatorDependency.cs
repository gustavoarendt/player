using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace PlayerControl.Infrastructure.CrossCutting.IoC
{
    public static class MediatorDependency
    {
        public static void AddMediatorDependency(this IServiceCollection services)
        {
            AppDomain currentDomain = AppDomain.CurrentDomain;

            currentDomain.Load("PlayerControl.Domain");
            currentDomain.Load("PlayerControl.Application");
            currentDomain.Load("PlayerControl.Infrastructure.CrossCutting");

            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies().Where(assembly => assembly.FullName!.ToLower().Contains("playercontrol")).ToArray());
        }
    }
}
