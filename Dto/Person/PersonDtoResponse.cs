namespace Dto.Person;

public record PersonDtoResponse
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string? MiddleName { get; set; }
    public string? LastName { get; set; }
    public bool? IsMale { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? Image { get; set; }
};