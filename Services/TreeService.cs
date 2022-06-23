using Domains;
using Dto;
using EntityFramework;
using Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;
using ServicesInterfaces;

namespace Services;

public class TreeService : ITreeService
{
    private readonly ApplicationDbContext _applicationDbContext;

    public TreeService(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    
    public async Task<FamilyTreeDto> CreateTree(FamilyTreeDto request, CancellationToken token)
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
        await _applicationDbContext.FamilyTrees.AddAsync(newTree, token);
        await _applicationDbContext.SaveChangesAsync(token);
        request.Id = newTree.Id;
        return request;
    }
}