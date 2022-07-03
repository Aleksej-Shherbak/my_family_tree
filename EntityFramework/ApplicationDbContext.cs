using Domains;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using File = Domains.File;

namespace EntityFramework;

public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<int>, int>
{
    public DbSet<FamilyTree> FamilyTrees { get; set; }
    public DbSet<Person> Persons { get; set; }
    public DbSet<Wife> Wives { get; set; }
    public DbSet<Husband> Husbands { get; set; }
    public DbSet<Family> Families { get; set; }
    public DbSet<PersonFact> PersonFacts { get; set; }
    public DbSet<File> Files { get; set; }
    public DbSet<Image> Images { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder
            .Entity<Family>()
            .HasMany(p => p.Children)
            .WithOne(p => p.ParentFamily)
            .HasForeignKey(p => p.ParentFamilyId);

        modelBuilder
            .Entity<Wife>()
            .HasMany(p => p.WifeFamilies)
            .WithOne(p => p.Wife)
            .HasForeignKey(p => p.WifeId);
        
        modelBuilder
            .Entity<Husband>()
            .HasMany(p => p.HusbandFamalies)
            .WithOne(p => p.Husband)
            .HasForeignKey(p => p.HusbandId);
        
        modelBuilder
            .Entity<FamilyTree>() 
            .HasOne(x => x.File)
            .WithOne()
            .HasForeignKey<FamilyTree>(x => x.FileId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}