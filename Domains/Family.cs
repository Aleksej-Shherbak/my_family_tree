namespace Domains;

public class Family
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public DateTime? MarriageDate { get; set; }
    public int HusbandId { get; set; }
    public Husband Husband { get; set; }
    public int WifeId { get; set; }
    public Wife Wife { get; set; }
    public List<Person> Children { get; set; }
}