namespace Domains;

public class PersonFact
{
    public int Id { get; set; }
    public int PersonId { get; set; }
    public Person Person { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DateTime { get; set; }
}