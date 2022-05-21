using System.Net;

namespace WebApi.Infrastructure.Exceptions;

public class InternalServerErrorException : HttpException
{
    public override HttpStatusCode StatusCode => HttpStatusCode.InternalServerError;

    public InternalServerErrorException(string? message) : base(!string.IsNullOrWhiteSpace(message)
        ? message
        : "Internal server error.")
    {
    }
}