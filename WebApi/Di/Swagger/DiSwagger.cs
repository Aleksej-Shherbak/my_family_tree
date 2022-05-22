using Microsoft.OpenApi.Models;

namespace WebApi.Di.Swagger;

public static class DiSwagger
{
    public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
    {
        services.AddSwaggerGen(option =>
        {
            option.SwaggerDoc("v1", new OpenApiInfo { Title = "My Family tree API", Version = "v1" });
        });

        return services;
    }
}