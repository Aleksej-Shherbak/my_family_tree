using Domains;

namespace WebApi.Dto.Auth;

public class LoginResponse
{
    public string Token { get; set; }
    public User User { get; set; }
}