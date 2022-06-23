using System.Net;

namespace Infrastructure.Exceptions;

public class MyFamilyTreeInternalServerErrorException : MyFamilyTreeException
{
    public override HttpStatusCode StatusCode => HttpStatusCode.InternalServerError;

    public MyFamilyTreeInternalServerErrorException(string? message) : base(!string.IsNullOrWhiteSpace(message)
        ? message
        : "Internal server error.")
    {
    }
}