using Microsoft.AspNetCore.Http;

namespace Dto.FamilyTree;

public class FamilyTreeDtoRequest
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int UserId { get; set; }
    public IFormFile? Image { get; set; }
}