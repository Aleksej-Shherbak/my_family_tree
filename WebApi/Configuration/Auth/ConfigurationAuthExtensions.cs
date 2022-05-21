using Microsoft.IdentityModel.Tokens;
using WebApi.Services.Auth;

namespace WebApi.Configuration.Auth;

public static class ConfigurationAuthExtensions
{
    public static IServiceCollection AddJwtConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        const string authScheme = "OAuth";
        services.AddAuthentication(authScheme)
            .AddJwtBearer(authScheme, options =>
            {
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    /*ValidIssuer = AuthOptions.ISSUER,

                    ValidateAudience = true,
                    ValidAudience = AuthOptions.AUDIENCE,
                    ValidateLifetime = true,
                    IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),*/
                    ValidateIssuerSigningKey = true,
                };
            });

        services.AddSingleton<JwtService>();
        services.AddSingleton<AuthService>();
        
        return services;
    }
}