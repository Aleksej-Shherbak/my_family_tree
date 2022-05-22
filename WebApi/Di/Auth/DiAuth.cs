using WebApi.Services.Auth;

namespace WebApi.Di.Auth;

public static class DiAuth
{
    public static IServiceCollection AddAuthConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication();
        services.AddAuthorization();
        services.AddScoped<AuthService>();
        
        return services;
    }
}