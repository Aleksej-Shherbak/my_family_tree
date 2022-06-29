using Microsoft.AspNetCore.Mvc;
using WebApi.Infrastructure.Extensions;

namespace WebApi.Controllers;

public class BaseController: Controller
{
    protected int UserId => HttpContext.User.GetLoggedInUserId<int>();
    protected string UserEmail => HttpContext.User.GetLoggedInUserEmail();
    protected string UserName => HttpContext.User.GetLoggedInUserName();
}