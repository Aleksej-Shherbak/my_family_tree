using System.Reflection;
using System.Text;
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
        var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var header = File.ReadAllText(Path.Combine(assemblyPath, "EmailTemplates", "Assets", "header.html"));
        var footer = File.ReadAllText(Path.Combine(assemblyPath, "EmailTemplates", "Assets", "footer.html"));

        // TODO try to get email from the database. If it does not exist then use default template.
        string defaultEmailTemplate = File.ReadAllText(Path.Combine(
            assemblyPath, "EmailTemplates", "DefaultTemplates", "confirm_account.html"));

        return new StringBuilder()
            .Append(header)
            .Append(defaultEmailTemplate.Replace("{link}", confirmAccountUrl))
            .Append(footer).ToString();
    }

    private string GenerateConfirmAccountUrl(string code, int userId)
    {
        return _options.UrlTemplate
            .Replace("{userId}", userId.ToString())
            .Replace("{code}", code);
    }
}