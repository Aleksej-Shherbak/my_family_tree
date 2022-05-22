using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Authorize]
[ApiController]
[Route("api")]
public class DefaultController : ControllerBase
{
    [HttpGet("")]
    public IActionResult Index()
    {
        return Ok(new {res = "hello world!"});
    }
}