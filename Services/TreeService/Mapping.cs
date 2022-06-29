using Domains;
using Dto.FamilyTree;

namespace Services.TreeService;

public static class Mapping
{
    public static FamilyTreeDtoResponse MapToDto(this FamilyTree source, string imagePath)
    {
        return new FamilyTreeDtoResponse
        {
            Description = source.Description,
            Id = source.Id,
            Title = source.Title,
            UserId = source.UserId,
            ImagePath = imagePath
        };
    }
}