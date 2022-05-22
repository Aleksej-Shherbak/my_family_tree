using Email.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NETCore.MailKit.Extensions;
using NETCore.MailKit.Infrastructure.Internal;
using ServicesInterfaces;

namespace Email;

public static class DiExtensions
{
    public static IServiceCollection AddEmailConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        var smtpSettings = configuration.GetSection(nameof(SmtpSettings)).Get<SmtpSettings>();

        if (smtpSettings == null)
        {
            throw new InvalidOperationException("There is no appropriate section in appsettings.json. " +
                                                $"It supposed to be section {nameof(SmtpSettings)}");
        }

        services.AddMailKit(config =>
        {
            config.UseMailKit(new MailKitOptions
            {
                Port = smtpSettings.Port,
                Password = smtpSettings.Password,
                Server = smtpSettings.Server,
                SenderEmail = smtpSettings.SenderEmail,
                SenderName = smtpSettings.SenderName,
                Account = smtpSettings.Account,
                Security = smtpSettings.Security
            }, ServiceLifetime.Singleton);
        });
        services.AddSingleton<IEmailNotificationService, EmailNotificationService>();
        return services;
    }
}