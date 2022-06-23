using System.Net;
using Infrastructure.Exceptions;
using Newtonsoft.Json;

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
        catch (MyFamilyTreeException e)
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

