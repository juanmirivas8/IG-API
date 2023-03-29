using System.Collections;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace IGAPI.Models;

[Index(nameof(Name),nameof(ProjectId), IsUnique = true)]
public class AreaEntity
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual ProjectEntity Project { get; set; }
    public int ProjectId { get; set; }
    
    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        return Name == ((AreaEntity)obj).Name;
    }
    
    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
    public override string ToString()
    {
        return $"{Name} - {ProjectId} - {Id}";
    }
}
