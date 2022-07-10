using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Dto.Person;

public record PersonDtoRequest
{
    [Required]
    public string FirstName { get; set; } = null!;
    public string? MiddleName { get; set; }
    public string? LastName { get; set; }
    public bool? IsMale { get; set; }
    public DateTime? BirthDate { get; set; }
    public IFormFile? Avatar { get; set; }
}