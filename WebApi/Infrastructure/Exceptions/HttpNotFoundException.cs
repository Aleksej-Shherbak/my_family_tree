using System.Net;

namespace WebApi.Infrastructure.Exceptions;

public class HttpNotFoundException : HttpException
{
    public HttpNotFoundException(string? message = null) : base(
        !string.IsNullOrEmpty(message) ? message : "Not found.")
    {
    }

    public override HttpStatusCode StatusCode => HttpStatusCode.NotFound;
}