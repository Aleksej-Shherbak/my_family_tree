using Domains;
using Dto.FamilyTree;

namespace Services.TreeServices;

public static class Mapping
{
    public static FamilyTreeDtoResponse MapToDto(this FamilyTree source)
    {
        return new FamilyTreeDtoResponse
        {
            Description = source.Description,
            Id = source.Id,
            Title = source.Title,
            UserId = source.UserId,
            Image = ((source.File as Image)!).PreviewName
        };
    }
}