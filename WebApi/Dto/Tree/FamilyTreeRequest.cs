using System.ComponentModel.DataAnnotations;
using WebApi.Attributes;

namespace WebApi.Dto.Tree;

public class FamilyTreeRequest
{
    [Required] public string Title { get; set; }
    public string Description { get; set; }

    [MaxFileSize(5 * 1024 * 1024)]
    [AllowedExtensions(new[] { ".jpg", ".png", ".jpeg" })]
    public IFormFile? Image { get; set; }
}