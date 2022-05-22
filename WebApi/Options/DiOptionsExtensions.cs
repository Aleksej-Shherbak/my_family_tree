using Email.Options;

namespace WebApi.Options;

public static class AddOptionsExtensions
{
    public static IServiceCollection AddOptionsConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<EmailConfirmation>(configuration.GetSection(nameof(EmailConfirmation)));
        services.Configure<SmtpSettings>(configuration.GetSection(nameof(SmtpSettings)));
        return services;
    }
}