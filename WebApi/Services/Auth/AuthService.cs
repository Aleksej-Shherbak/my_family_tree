using Domains;
using Infrastructure.Dto;
using Microsoft.AspNetCore.Identity;
using WebApi.Dto.Auth;
using WebApi.Infrastructure.Exceptions;

namespace WebApi.Services.Auth;

public class AuthService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly JwtService _jwtService;

    public AuthService(UserManager<User> userManager, SignInManager<User> signInManager, JwtService jwtService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtService = jwtService;
    }

    public async Task<BaseServiceResponse<string>> LoginAsync(LoginRegisterRequest loginRegisterRequest)
    {
        var user = await _userManager.FindByEmailAsync(loginRegisterRequest.Email);

        if (user == null)
        {
            throw new UnauthorizedAccessException();
        }

        var result = await _signInManager.PasswordSignInAsync(user, loginRegisterRequest.Password, false, false);

        if (!result.Succeeded)
        {
            throw new HttpUnauthorizedException();
        }
        
        var token = _jwtService.GenerateJwtToken(user);
        return new BaseServiceResponse<string>(token);
    }
}