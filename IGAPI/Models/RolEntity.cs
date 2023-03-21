using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IGAPI.Models.enums;


namespace IGAPI.Models;

[Table("Roles")]
public class RolEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Project{get; set;} = string.Empty;
    public string Area { get; set; } = string.Empty;
    public RolEnum Rol { get; set; }
    public LocalizationEnum Localization { get; set; }
    public string Description { get; set; } = string.Empty;
    public RolStatusEnum Status { get; set; }
    public string prueba { get; set; } = string.Empty;
    public int Vacancies { get; set; } = 1;
    [DataType(DataType.Date)]
    public DateTime CreationDate { get; set; }
    public DateTime ClosingDate { get; set; }
    public DateTime LastUpdate { get; set; }
    //public List<CandidateEntity> Candidates { get; set; } = new();
}