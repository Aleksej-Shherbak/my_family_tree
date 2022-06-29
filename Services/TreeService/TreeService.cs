using Domains;
using Dto.FamilyTree;
using EntityFramework;
using Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;
using ServicesInterfaces;

namespace Services.TreeService;

public class TreeService : ITreeService
{
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly IFileService _fileService;

    public TreeService(ApplicationDbContext applicationDbContext, IFileService fileService)
    {
        _applicationDbContext = applicationDbContext;
        _fileService = fileService;
    }
    
    public async Task<FamilyTreeDtoRequest> CreateTree(FamilyTreeDtoRequest request, CancellationToken token)
    {
        var isUserFound = await _applicationDbContext.Users.AnyAsync(x => x.Id == request.UserId, token);

        if (!isUserFound)
        {
            throw new MyFamilyTreeNotFoundException($"User not with id: {request.UserId} found.");
        }
        
        var newTree = new FamilyTree
        {
            Description = request.Description,
            Title = request.Title,
            UserId = request.UserId,
            CreateAt = DateTime.UtcNow
        };
        if (request.Image != null)
        {
            var file = await _fileService.SaveFile(request.Image, request.UserId, token);
            newTree.FileId = file.Id;
        }
        await _applicationDbContext.FamilyTrees.AddAsync(newTree, token);
        await _applicationDbContext.SaveChangesAsync(token);
        request.Id = newTree.Id;
        return request;
    }

    public async Task<FamilyTreeDtoResponse[]> GetTrees(int userId, CancellationToken cancellationToken)
    {
        return await _applicationDbContext.FamilyTrees.Where(x => x.UserId == userId)
            .Select(x => x.MapToDto(_fileService.GetFileFullPath(userId, x.File.Name)))
            .ToArrayAsync(cancellationToken);
    }
}