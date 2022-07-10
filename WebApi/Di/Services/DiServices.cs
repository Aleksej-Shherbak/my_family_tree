using Services.FamilyServices;
using Services.FileServices;
using Services.PersonServices;
using Services.TreeServices;
using ServicesInterfaces;

namespace WebApi.Di.Services;

public static class DiServices
{
    public static IServiceCollection AddServicesConfiguration(this IServiceCollection services)
    {
        services.AddScoped<ITreeService, TreeService>();
        services.AddScoped<IFileService, FileService>();
        services.AddScoped<IFamilyService, FamilyService>();
        services.AddScoped<IFilePathService, FilePathService>();
        services.AddScoped<IPersonService, PersonService>();
        return services;
    }
}