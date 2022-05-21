using System.Net;

namespace WebApi.Infrastructure.Exceptions;

public class HttpUnauthorizedException : HttpException
{
    public HttpUnauthorizedException(string? message = null) : base(
        !string.IsNullOrEmpty(message) ? message : "Not authorized.")
    {
    }

    public override HttpStatusCode StatusCode => HttpStatusCode.Unauthorized;
}