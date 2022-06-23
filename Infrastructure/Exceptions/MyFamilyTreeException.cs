using System.Net;

namespace Infrastructure.Exceptions;

public abstract class MyFamilyTreeException : Exception
{
    public MyFamilyTreeException() {  }
    
    public MyFamilyTreeException(string? message)
        : base(message)
    {
    }
    
    public abstract HttpStatusCode StatusCode { get; }
}