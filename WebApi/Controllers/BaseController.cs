using Infrastructure.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class BaseController: Controller
{
    protected int UserId => HttpContext.User.GetLoggedInUserId<int>();
    protected string UserEmail => HttpContext.User.GetLoggedInUserEmail();
    protected string UserName => HttpContext.User.GetLoggedInUserName();
}