using Infrastructure.Di.Auth;
using WebApi.Services.Auth;

namespace WebApi.Di.Auth;

public static class DiAuth
{
    public static IServiceCollection AddAuthConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddJwtAuthConfiguration(configuration);
        services.AddScoped<AuthService>();
        services.AddSingleton<JwtService>();
        return services;
    }
}