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
            Trees = new []
            {
                new FamilyTree
                {
                    Id = 1,
                    Title = "Family tree 1",
                    Description = "Description family tree 1"
                },
                new FamilyTree
                {
                    Id = 2,
                    Title = "Family tree 2",
                    Description = "Description family tree 2"
                }
            }
        });
    }
}