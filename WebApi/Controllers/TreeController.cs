using Dto.FamilyTree;
using Infrastructure.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServicesInterfaces;

namespace WebApi.Controllers;

[Authorize]
[Route("api/trees")]
[ApiController]
public class TreeController : BaseController
{
    private readonly ITreeService _treeService;

    public TreeController(ITreeService treeService)
    {
        _treeService = treeService;
    }
    
    [HttpGet]
    public async Task<FamilyTreeDtoResponse[]> Index(CancellationToken token)
    {
        return await _treeService.GetTrees(UserId, token);
    }

    [HttpPost]
    public async Task<FamilyTreeDtoResponse> Create([FromForm] FamilyTreeDtoRequest request, CancellationToken cancellationToken)
    {
        var userId = HttpContext.User.GetLoggedInUserId<int>();
        return await _treeService.CreateTree(userId, request, cancellationToken);
    }
}