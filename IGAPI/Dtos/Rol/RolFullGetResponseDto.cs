
using IGAPI.Models;
using IGAPI.Models.enums;

namespace IGAPI.Dtos.Rol;

public class RolFullGetResponseDto
{
    public int Id { get; set; }
    public string Project{get; set;} = string.Empty;
    public string Area { get; set; } = string.Empty;
    public RolEnum Rol { get; set; }
    public LocalizationEnum Localization { get; set; }
    public string Description { get; set; } = string.Empty;
    public RolStatusEnum Status { get; set; }
    public int Vacancies { get; set; } = 1;
    public DateTime CreationDate { get; set; }
    public DateTime ClosingDate { get; set; }
    public DateTime LastUpdate { get; set; }
    public List<CandidateEntity> Candidates { get; set; } = new();
}