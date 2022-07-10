using Domains.Enums;

namespace Domains;

public class Person
{
    public int Id { get; set; }
    public int? FamilyTreeId { get; set; }
    public FamilyTree? FamilyTree { get; set; }
    public string FirstName { get; set; } = null!;
    public string? MiddleName { get; set; }
    public string? LastName { get; set; }
    public List<PersonFact>? PersonFacts { get; set; }
    public Gender? Gender { get; set; }
    public DateTime? BirthDate { get; set; }
    public int? ParentFamilyId { get; set; }
    public Family? ParentFamily { get; set; }
    public int? AvatarId { get; set; }
    public File? Avatar { get; set; }
    public int? UserId { get; set; }
    public User? User { get; set; }
}