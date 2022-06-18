using Microsoft.AspNetCore.Mvc;
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

    public AuthController(AuthService authService)
    {
        _authService = authService;
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

        Response.Cookies.Append("AuthCookie", loginResponse.Token, new CookieOptions
        {
            Secure = true,
            HttpOnly = true,
            SameSite = SameSiteMode.None
        });
        return loginResponse.User.MapToDto();
    }

    [HttpPost("confirm-account")]
    public async Task<IActionResult> ConfirmAccount(ConfirmAccountRequest request)
    {
        await _authService.ConfirmEmailAsync(request);
        return Ok();
    }
}