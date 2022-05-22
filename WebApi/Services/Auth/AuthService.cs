using Domains;
using Microsoft.AspNetCore.Identity;
using ServicesInterfaces;
using WebApi.Dto.Auth;
using WebApi.Infrastructure.Exceptions;

namespace WebApi.Services.Auth;

public class AuthService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IEmailNotificationService _emailNotificationService;
    
    public AuthService(
        UserManager<User> userManager,
        SignInManager<User> signInManager,
        IEmailNotificationService emailNotificationService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _emailNotificationService = emailNotificationService;
    }

    public async Task LoginAsync(LoginRequest request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user == null)
        {
            throw new HttpUnauthorizedException();
        }

        var result = await _signInManager.PasswordSignInAsync(user, request.Password, false, false);

        if (!result.Succeeded)
        {
            throw new HttpUnauthorizedException();
        }

        await _signInManager.SignInAsync(user, false);
    }

    public async Task RegisterAsync(RegisterRequest request)
    {
        await ValidateIfCredentialsAreFreeOrThrowAsync(request);
        var user = new User
        {
            Email = request.Email,
            UserName = request.Username,
        };
        var res = await _userManager.CreateAsync(user, request.Password);
        // TODO show password requirements errors!

        if (!res.Succeeded)
        {
            // TODO log it.
            throw new InternalServerErrorException("Failed to create user.");
        }

        // TODO enqueue this to RabbitMQ.
        var confirmationCode = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        await _emailNotificationService.SendConfirmAccountEmailAsync(confirmationCode, user.Id, user.Email);
    }

    public async Task ConfirmEmailAsync(ConfirmAccountRequest request)
    {
        var user = await _userManager.FindByIdAsync(request.UserId.ToString());
        if (user == null)
        {
            throw new HttpNotFoundException("User not found!");
        }

        var res = await _userManager.ConfirmEmailAsync(user, request.Code);
        // TODO process Remember me 
        if (!res.Succeeded)
        {
            // TODO log identity errors
            throw new BusinessLogicException("Something went wrong.");
        }
        
        var rememberMe = false;
        await _signInManager.SignInAsync(user, rememberMe);
    }

    private async Task ValidateIfCredentialsAreFreeOrThrowAsync(RegisterRequest request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user != null)
        {
            throw new BusinessLogicException("Email is already busy!");
        }

        user = await _userManager.FindByNameAsync(request.Username);

        if (user != null)
        {
            throw new BusinessLogicException("Username is already busy!");
        }
    }
}