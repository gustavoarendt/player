using Keycloak.AuthServices.Authentication;
using Keycloak.AuthServices.Authorization;

namespace PlayerControl.Api.Security
{
    public static class KeycloakDependency
    {
        public static IServiceCollection AddKeycloakDependency(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddKeycloakAuthentication(configuration);
            services.AddKeycloakAuthorization(configuration);
            return services;
        }
    }
}
