using System.Reflection;
using Email.Options;
using Microsoft.Extensions.Options;
using NETCore.MailKit.Core;
using ServicesInterfaces;

namespace Email;

public class EmailNotificationService : IEmailNotificationService
{
    private readonly IEmailService _emailService;
    private readonly EmailConfirmation _options;

    public EmailNotificationService(
        IOptions<EmailConfirmation> options,
        IEmailService emailService)
    {
        _emailService = emailService;
        _options = options.Value;
    }

    public async Task SendConfirmAccountEmailAsync(string code, int userId, string email)
    {
        var confirmAccountUrl = GenerateConfirmAccountUrl(code, userId);
        var emailTemplate = GetEmailTemplate(confirmAccountUrl);
        await _emailService.SendAsync(email, "Confirm your account", emailTemplate, true);
    }

    private string GetEmailTemplate(string confirmAccountUrl)
    {
        string emailTemplate = File.ReadAllText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "EmailTemplates", "confirm_account.html"));

        return emailTemplate.Replace("{link}", confirmAccountUrl);
    }

    private string GenerateConfirmAccountUrl(string code, int userId)
    {
        return _options.UrlTemplate
            .Replace("{userId}", userId.ToString())
            .Replace("{code}", code);
    }
}