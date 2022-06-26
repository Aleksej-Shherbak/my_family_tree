using System.Security.Claims;
using Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServicesInterfaces;
using WebApi.Dto;
using WebApi.Dto.Tree;
using WebApi.Infrastructure.Extensions;

namespace WebApi.Controllers;

[Authorize]
[Route("api/trees")]
[ApiController]
public class TreeController : Controller
{
    private readonly ITreeService _treeService;

    public TreeController(ITreeService treeService)
    {
        _treeService = treeService;
    }
    
    [HttpGet]
    public IActionResult Index()
    {
        return Ok(new FamilyTreeList
        {
        });
    }

    [HttpPost]
    public async Task<BaseResponse<int>> Create([FromForm] FamilyTreeRequest request, CancellationToken token)
    {
        var res = await _treeService.CreateTree(new FamilyTreeDto
        {
            Description = request.Description,
            Title = request.Title,
            UserId = HttpContext.User.GetLoggedInUserId<int>()
        }, token);

        return new BaseResponse<int>
        {
            IsSuccess = true,
            Data = res.Id
        };
    }
}