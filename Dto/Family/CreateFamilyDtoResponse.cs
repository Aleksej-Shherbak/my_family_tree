namespace Dto.Family;

public record CreateFamilyDtoResponse
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public DateTime? MarriageDate { get; set; }
}