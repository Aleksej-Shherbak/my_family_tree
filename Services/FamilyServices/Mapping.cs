using Domains;
using Dto.Family;

namespace Services.FamilyServices;

public static class Mapping
{
    public static CreateFamilyDtoResponse MapToDto(this Family family)
    {
        return new CreateFamilyDtoResponse
        {
            Id = family.Id,
            Description = family.Description,
            Title = family.Title,
            MarriageDate = family.MarriageDate
        };
    }
}