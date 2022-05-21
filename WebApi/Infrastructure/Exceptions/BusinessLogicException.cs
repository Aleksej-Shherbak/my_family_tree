using System.Net;

namespace WebApi.Infrastructure.Exceptions;

public class BusinessLogicException: HttpException
{
    public BusinessLogicException(string message): base(message)
    {
    }

    public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
    
    
}