using System.ComponentModel.DataAnnotations;
using Dto.Attributes;
using Microsoft.AspNetCore.Http;

namespace Dto.FamilyTree;

public record FamilyTreeDtoRequest
{
    [Required]
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    [MaxFileSize(5 * 1024 * 1024)]
    [AllowedExtensions(new[] { ".jpg", ".png", ".jpeg" })]
    public IFormFile? Image { get; set; }
}