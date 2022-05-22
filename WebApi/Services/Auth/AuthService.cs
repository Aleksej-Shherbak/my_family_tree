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
    private readonly JwtService _jwtService;

    public AuthService(
        UserManager<User> userManager,
        SignInManager<User> signInManager,
        IEmailNotificationService emailNotificationService,
        JwtService jwtService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _emailNotificationService = emailNotificationService;
        _jwtService = jwtService;
    }

    public async Task<LoginResponse> LoginAsync(LoginRequest request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user == null)
        {
            throw new HttpUnauthorizedException("Invalid email or password.");
        }

        var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

        if (!result.Succeeded)
        {
            throw new HttpUnauthorizedException("Invalid email or password.");
        }

        var jwt = _jwtService.GenerateJwtToken(user);
        return new LoginResponse
        {
            Token = jwt
        };
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

    public async Task<LoginResponse> ConfirmEmailAsync(ConfirmAccountRequest request)
    {
        var user = await _userManager.FindByIdAsync(request.UserId.ToString());
        if (user == null)
        {
            throw new HttpNotFoundException("User not found!");
        }

        var res = await _userManager.ConfirmEmailAsync(user, request.Code);
        if (!res.Succeeded)
        {
            // TODO log identity errors
            throw new BusinessLogicException("Something went wrong.");
        }
        
        var jwt = _jwtService.GenerateJwtToken(user);
        return new LoginResponse
        {
            Token = jwt
        };
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