using Domains;
using Dto.FamilyTree;
using EntityFramework;
using Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;
using ServicesInterfaces;

namespace Services.TreeServices;

public class TreeService : ITreeService
{
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly IFileService _fileService;

    public TreeService(ApplicationDbContext applicationDbContext, IFileService fileService)
    {
        _applicationDbContext = applicationDbContext;
        _fileService = fileService;
    }
    
    public async Task<FamilyTreeDtoResponse> CreateTree(int userId, FamilyTreeDtoRequest request, CancellationToken cancellationToken)
    {
        var newTree = new FamilyTree
        {
            Description = request.Description,
            Title = request.Title,
            UserId = userId,
            CreateAt = DateTime.UtcNow
        };
        if (request.Image != null)
        {
            var file = await _fileService.SaveFile(request.Image, userId, cancellationToken);
            newTree.FileId = file.Id;
        }
        await _applicationDbContext.FamilyTrees.AddAsync(newTree, cancellationToken);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        
        return newTree.MapToDto();
    }

    public async Task<FamilyTreeDtoResponse[]> GetTrees(int userId, CancellationToken cancellationToken)
    {
        return (await _applicationDbContext.FamilyTrees
            .Include(x => x.File)
            .Where(x => x.UserId == userId)
            .ToArrayAsync(cancellationToken))
            .Select(x => x.MapToDto())
            .ToArray();
    }

    public async Task<FamilyTreeDtoResponse?> GetTree(int userId, int treeId, CancellationToken cancellationToken)
    {
        return (await _applicationDbContext.FamilyTrees
            .Include(x => x.File)
            .Where(x => x.UserId == userId && x.Id == treeId)
            .FirstOrDefaultAsync(cancellationToken))
            ?.MapToDto();
    }
}