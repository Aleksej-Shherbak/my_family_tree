using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Authorize]
[Route("")]
public class DefaultController : Controller
{
    [HttpGet("")]
    public IActionResult Index()
    {
        return Ok(new {res = "hello world!"});
    }
}