using Microsoft.OpenApi.Models;

namespace PlayerControl.Api.ApiDependencies
{
    public static class DocumentDependency
    {
        public static IServiceCollection AddDocumentDependency(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo { Title = "Player Control", Version = "v1" });
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Insert a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
            });
            return services;
        }

        public static WebApplication AddSwaggerUIDependency(this WebApplication webApplication)
        {
            if (!webApplication.Environment.IsProduction())
            {
                webApplication.UseSwagger();
                webApplication.UseSwaggerUI();
            }
            return webApplication;
        }
    }
}
