using System.ComponentModel.DataAnnotations;

namespace Dto.Family;

public record CreateFamilyDtoRequest
{
    [Required]
    public string Title { get; set; }
    public string? Description { get; set; }
    public DateTime? MarriageDate { get; set; }
}