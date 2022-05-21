using Microsoft.IdentityModel.Tokens;
using WebApi.Configuration.Options.Models;
using WebApi.Services.Auth;

namespace WebApi.Configuration.Auth;

public static class ConfigurationAuthExtensions
{
    public static IServiceCollection AddJwtConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        const string authScheme = "OAuth";
        var jwtOptions = configuration.GetSection(nameof(JwtOptions)).Get<JwtOptions>();
        
        services.AddAuthentication(authScheme)
            .AddJwtBearer(authScheme, options =>
            {
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = jwtOptions.Issuer,
                    ValidateAudience = true,
                    ValidAudience = jwtOptions.Audience,
                    ValidateLifetime = true,
                    IssuerSigningKey = JwtService.GetSymmetricSecurityKey(jwtOptions.Secret),
                    ValidateIssuerSigningKey = true,
                };
            });

        services.AddSingleton<JwtService>();
        services.AddScoped<AuthService>();
        
        return services;
    }
}