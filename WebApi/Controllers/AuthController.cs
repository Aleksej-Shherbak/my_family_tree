using Dto.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebApi.Dto;
using WebApi.Dto.Auth;
using WebApi.Mapping.Auth;
using WebApi.Services.Auth;

namespace WebApi.Controllers;

[ApiController]
[Route("api")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;
    private readonly AuthOptions _authOptions;

    public AuthController(AuthService authService, IOptions<AuthOptions> authOptions)
    {
        _authService = authService;
        _authOptions = authOptions.Value;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        await _authService.RegisterAsync(request);
        return Ok();
    }

    [HttpPost("login")]
    public async Task<UserDto> Login(LoginRequest request)
    {
        var loginResponse = await _authService.LoginAsync(request);

        Response.Cookies.Append(_authOptions.AuthCookieName, loginResponse.Token, new CookieOptions
        {
            Secure = true,
            HttpOnly = true,
            SameSite = SameSiteMode.None
        });
        return loginResponse.User.MapToDto();
    }

    [HttpGet("logout")]
    public IActionResult Logout()
    {
        Response.Cookies.Delete(_authOptions.AuthCookieName);
        return Ok();
    }

    [HttpPost("confirm-account")]
    public async Task<IActionResult> ConfirmAccount(ConfirmAccountRequest request)
    {
        await _authService.ConfirmEmailAsync(request);
        return Ok();
    }
}