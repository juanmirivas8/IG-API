using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace IGAPI.Models;

[Table("Positions")]
public class PositionEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public virtual ProjectEntity Project { get; set; }
    public virtual AreaEntity Area { get; set; }
    public virtual RolEntity Rol { get; set; }
    public virtual SubRolEntity SubRol { get; set; }
    public virtual LocalizationEntity Localization { get; set; }
    public virtual PositionStatusEntity Status { get; set; }
    public string Description { get; set; }
    public int Vacancies { get; set; }
    [DataType(DataType.Date)]
    public DateTime CreationDate { get; set; }
    [DataType(DataType.Date)]
    public DateTime? ClosingDate { get; set; }
    [DataType(DataType.Date)]
    public DateTime LastUpdate { get; set; }
    public virtual IEnumerable<ApplicationEntity> Applications { get; set; }
}