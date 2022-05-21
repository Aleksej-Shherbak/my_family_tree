namespace ServicesInterfaces;

public interface IEmailNotificationService
{
    Task SendConfirmAccountEmailAsync(string code, int userId, string email);
}