using Domains;
using Dto.Family;
using EntityFramework;
using Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;
using ServicesInterfaces;

namespace Services.FamilyServices;

public class FamilyService: IFamilyService
{
    private readonly ApplicationDbContext _applicationDbContext;

    public FamilyService(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    
    public async Task<CreateFamilyDtoResponse> CreateFamily(int familyTreeId, CreateFamilyDtoRequest request, CancellationToken cancellationToken)
    {
        var familyTree = _applicationDbContext.FamilyTrees
            .FirstOrDefaultAsync(x => x.Id == familyTreeId, cancellationToken);

        if (familyTree == null)
        {
            throw new MyFamilyTreeNotFoundException($"Family tree with id {familyTreeId} has not been not found");
        }

        var newFamily = new Family
        {
            FamilyTreeId = familyTreeId,
            Title = request.Title,
            Description = request.Description,
            MarriageDate = request.MarriageDate
        };

        await _applicationDbContext.Families.AddAsync(newFamily, cancellationToken);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);

        return newFamily.MapToDto();
    }
}