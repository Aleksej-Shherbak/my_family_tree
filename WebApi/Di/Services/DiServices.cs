using Services;
using ServicesInterfaces;

namespace WebApi.Di.Services;

public static class DiServices
{
    public static IServiceCollection AddServicesConfiguration(this IServiceCollection services)
    {
        services.AddScoped<ITreeService, TreeService>();
        return services;
    }
}