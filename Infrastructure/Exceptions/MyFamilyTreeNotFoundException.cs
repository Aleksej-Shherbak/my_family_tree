using System.Net;

namespace Infrastructure.Exceptions;

public class MyFamilyTreeNotFoundException : MyFamilyTreeException
{
    public MyFamilyTreeNotFoundException(string? message = null) : base(
        !string.IsNullOrEmpty(message) ? message : "Not found.")
    {
    }

    public override HttpStatusCode StatusCode => HttpStatusCode.NotFound;
}