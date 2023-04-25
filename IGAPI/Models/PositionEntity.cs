using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace IGAPI.Models;

[Table("Positions")]
public class PositionEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public virtual ProjectEntity Project { get; set; }
    public virtual AreaEntity Area { get; set; }
    public virtual RolEntity Rol { get; set; }
    public virtual SubRolEntity SubRol { get; set; }
    public virtual LocalizationEntity Localization { get; set; }
    public virtual PositionStatusEntity Status { get; set; }
    public string Description { get; set; } = string.Empty;
    public int Vacancies { get; set; } = 1;
    [DataType(DataType.Date)]
    public DateTime CreationDate { get; set; }
    [DataType(DataType.Date)]
    public DateTime ClosingDate { get; set; }
    [DataType(DataType.Date)]
    public DateTime LastUpdate { get; set; }
}