using Services;
using Services.FileService;
using Services.TreeService;
using ServicesInterfaces;

namespace WebApi.Di.Services;

public static class DiServices
{
    public static IServiceCollection AddServicesConfiguration(this IServiceCollection services)
    {
        services.AddScoped<ITreeService, TreeService>();
        services.AddScoped<IFileService, FileService>();
        return services;
    }
}