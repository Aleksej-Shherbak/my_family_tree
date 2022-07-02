using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Di.Cors;

public static class DiCors
{
    public static IServiceCollection AddCorsConfiguration(this IServiceCollection services, string? url = null)
    {
        services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy  =>
            {
                policy.WithOrigins(url ?? "http://localhost:3000")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        });

        
        return services;
    }
}