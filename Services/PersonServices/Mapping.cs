using Domains;
using Domains.Enums;
using Dto.Person;

namespace Services.PersonServices;

public static class Mapping
{
    public static PersonDtoResponse MapToDto(this Person person)
    {
        var res =  new PersonDtoResponse
        {
            Id = person.Id,
            Image = person.Avatar?.Name,
            BirthDate = person.BirthDate,
            FirstName = person.FirstName,
            LastName = person.LastName,
            MiddleName = person.MiddleName
        };

        if (person.Gender.HasValue)
        {
            res.IsMale = person.Gender.Value == Gender.Male;
        }

        return res;
    }
}