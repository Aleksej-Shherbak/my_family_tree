using System.Net;

namespace WebApi.Infrastructure.Exceptions;

public abstract class HttpException : Exception
{
    public HttpException() {  }
    
    public HttpException(string? message)
        : base(message)
    {
    }
    
    public abstract HttpStatusCode StatusCode { get; }
}