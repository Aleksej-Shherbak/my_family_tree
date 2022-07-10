namespace Dto.FamilyTree;

public record FamilyTreeDtoResponse
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public int UserId { get; set; }
    public string? Image { get; set; }
}