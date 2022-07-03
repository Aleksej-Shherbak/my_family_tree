using System.ComponentModel.DataAnnotations.Schema;

namespace Domains;

public class FamilyTree
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public int FileId { get; set; }
    public File File { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreateAt { get; set; }
    public bool IsPublic { get; set; }
}