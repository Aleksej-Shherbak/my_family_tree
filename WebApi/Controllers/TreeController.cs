using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dto.Tree;

namespace WebApi.Controllers;

[Authorize]
[Route("api")]
[ApiController]
public class TreeController : Controller
{
    [HttpGet("trees")]
    public IActionResult Index()
    {
        return Ok(new FamilyTreeList
        {
        });
    }
}