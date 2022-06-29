using Dto.FamilyTree;
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
    public async Task<BaseResponse<int>> Create([FromForm] FamilyTreeRequest request, CancellationToken token)
    {
        var res = await _treeService.CreateTree(new FamilyTreeDtoRequest
        {
            Description = request.Description,
            Title = request.Title,
            UserId = HttpContext.User.GetLoggedInUserId<int>(),
            Image = request.Image
        }, token);

        return new BaseResponse<int>
        {
            IsSuccess = true,
            Data = res.Id
        };
    }
}