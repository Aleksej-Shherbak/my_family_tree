using System.Net.Mail;
using Domains;
using Microsoft.AspNetCore.Identity;

namespace CreateUserApp;

public class Validation
{
    private readonly UserManager<User> _userManager;

    public Validation(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public void ValidateUsernameOrThrow(string? username)
    {
        if (string.IsNullOrWhiteSpace(username))
        {
            throw new CreateUserException("Username can not be empty!");
        }

        if (IsUsernameBusy(username))
        {
            throw new CreateUserException("Username is already busy!");
        }
    }

    public void ValidateEmailOrThrow(string? email)
    {
        ValidateIfEmailCorrectOrThrow(email);

        if (IsUsernameBusy(email))
        {
            throw new CreateUserException("Email is already busy!");
        }
    }

    private bool IsUsernameBusy(string username) =>
        _userManager.FindByNameAsync(username).GetAwaiter().GetResult() != null;

    private bool IsEmailBusy(string email) =>
        _userManager.FindByEmailAsync(email).GetAwaiter().GetResult() != null;

    public void ValidateIfEmailCorrectOrThrow(string? email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            throw new CreateUserException("Email can not be empty!");
        }

        try
        {
            MailAddress m = new MailAddress(email);
        }
        catch (FormatException)
        {
            throw new CreateUserException("Invalid email!");
        }

        ;
    }
}