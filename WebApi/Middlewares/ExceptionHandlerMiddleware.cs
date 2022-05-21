using System.Net;
using Newtonsoft.Json;
using WebApi.Infrastructure.Exceptions;

namespace WebApi.Middlewares;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (HttpException e)
        {
            await HandleException(httpContext, e.StatusCode, e);
        }
    }

    private async Task HandleException(HttpContext httpContext, HttpStatusCode code, Exception exception)
    {
        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = (int)code;
        await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(new { error = exception.Message }));
    }
}

public static class ExceptionHandlerMiddlewareExtensions
{
    public static IApplicationBuilder UseExceptionHandlerMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}

