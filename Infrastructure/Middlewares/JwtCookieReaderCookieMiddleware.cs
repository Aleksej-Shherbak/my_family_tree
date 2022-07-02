using Dto.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Infrastructure.Middlewares;

/// <summary>
/// Adds JWT token from cookie to HTTP Authorization header if it exists.
/// </summary>
public class JwtCookieReaderCookieMiddleware
{
    private readonly RequestDelegate _next;
    private readonly AuthOptions _authOptions;

    public JwtCookieReaderCookieMiddleware(RequestDelegate next, IOptions<AuthOptions> authOptions)
    {
        _next = next;
        _authOptions = authOptions.Value;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        if (httpContext.Request.Cookies.TryGetValue(_authOptions.AuthCookieName, out var token))
        {
            httpContext.Request.Headers.Add("Authorization",  $"Bearer {token}");
        }
        await _next(httpContext);
    }
}

public static class JwtCookieReaderCookieMiddlewareExtension
{
    public static IApplicationBuilder UseJwtCookieReaderCookie(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<JwtCookieReaderCookieMiddleware>();
    }
}