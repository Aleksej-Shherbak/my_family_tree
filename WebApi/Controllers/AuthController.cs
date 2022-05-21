using Microsoft.AspNetCore.Mvc;
using WebApi.Dto.Auth;
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
    public async Task<LoginResponse> Login(LoginRequest request) =>
        await _authService.LoginAsync(request);

    [HttpPost("confirm-account")]
    public async Task<LoginResponse> ConfirmAccount(ConfirmAccountRequest request)
        => await _authService.ConfirmEmailAsync(request);
}