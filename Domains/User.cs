using Microsoft.AspNetCore.Identity;

namespace Domains;

public class User: IdentityUser<int>
{
    public List<FamilyTree> FamilyTrees { get; set; }
    public List<Person>? Persons { get; set; }
}