using Email.Options;
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
        return services;
    }
}