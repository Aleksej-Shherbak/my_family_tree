using System.ComponentModel.DataAnnotations;

namespace WebApi.Dto.Tree;

public class FamilyTreeRequest
{
    [Required]
    public string Title { get; set; }
    [Required]
    public string Description { get; set; }
}