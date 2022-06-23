using System.Net;

namespace Infrastructure.Exceptions;

public class MyFamilyTreeBusinessLogicException: MyFamilyTreeException
{
    public MyFamilyTreeBusinessLogicException(string message): base(message)
    {
    }

    public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
    
    
}