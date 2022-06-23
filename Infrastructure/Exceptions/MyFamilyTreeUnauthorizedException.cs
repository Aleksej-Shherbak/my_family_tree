using System.Net;

namespace Infrastructure.Exceptions;

public class MyFamilyTreeUnauthorizedException : MyFamilyTreeException
{
    public MyFamilyTreeUnauthorizedException(string? message = null) : base(
        !string.IsNullOrEmpty(message) ? message : "Not authorized.")
    {
    }

    public override HttpStatusCode StatusCode => HttpStatusCode.Unauthorized;
}