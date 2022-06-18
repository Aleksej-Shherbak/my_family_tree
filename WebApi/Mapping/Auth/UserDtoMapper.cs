using Domains;
using WebApi.Dto;

namespace WebApi.Mapping.Auth;

public static class UserDtoMapper
{
    public static UserDto MapToDto(this User source)
    {
        return new()
        {
            Id = source.Id,
            Email = source.Email,
            Username = source.UserName,
        };
    }
}