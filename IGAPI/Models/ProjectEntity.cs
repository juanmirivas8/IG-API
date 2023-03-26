using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IGAPI.Models;

[Index(nameof(Name), IsUnique = true)]
public class ProjectEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    
    public virtual List<AreaEntity> Areas { get; set; } = new();
}