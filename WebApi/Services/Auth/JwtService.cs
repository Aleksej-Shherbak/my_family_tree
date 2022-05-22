using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domains;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WebApi.Options.Models;

namespace WebApi.Services.Auth;

public class JwtService
{
    private readonly JwtOptions _options;

    public JwtService(IOptions<JwtOptions> options)
    {
        _options = options.Value;
    }

    public static SymmetricSecurityKey GetSymmetricSecurityKey(string secret) => new(Encoding.UTF8.GetBytes(secret));
    
    public string GenerateJwtToken(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Name, user.UserName),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
        };

        var signinCredentials = new SigningCredentials(GetSymmetricSecurityKey(_options.Secret), 
            SecurityAlgorithms.HmacSha256);
        
        var token = new JwtSecurityToken(
            _options.Issuer, 
            _options.Audience,
            notBefore: DateTime.Now, 
            expires: DateTime.Now.AddMinutes(_options.TokenLifeExpectancyMinutes),
            claims: claims,
            signingCredentials: signinCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}