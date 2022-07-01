using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domains;

public class File
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public string Name { get; set; }
}