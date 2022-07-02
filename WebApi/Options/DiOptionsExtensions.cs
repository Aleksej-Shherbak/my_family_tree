using Dto.Options;
using Email.Options;
using Services.FileService;
using WebApi.Options.Models;

namespace WebApi.Options;

public static class AddOptionsExtensions
{
    public static IServiceCollection AddOptionsConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));
        services.Configure<EmailConfirmation>(configuration.GetSection(nameof(EmailConfirmation)));
        services.Configure<SmtpSettings>(configuration.GetSection(nameof(SmtpSettings)));
        services.Configure<AuthOptions>(configuration.GetSection(nameof(AuthOptions)));
        services.Configure<FileStorageOptions>(configuration.GetSection(nameof(FileStorageOptions)));
        return services;
    }
}