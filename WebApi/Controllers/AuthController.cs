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
    public IActionResult Register(LoginRegisterRequest request)
    {
        return Ok();
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRegisterRequest request)
    {
        var res = await _authService.LoginAsync(request);
        return Ok(new LoginRegisterResponse
        {
            Token = res.Data 
        });
    }
}