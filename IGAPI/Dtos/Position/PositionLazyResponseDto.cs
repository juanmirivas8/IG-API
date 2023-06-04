using System.ComponentModel.DataAnnotations;
using IGAPI.Dtos.Area;
using IGAPI.Dtos.Localization;
using IGAPI.Dtos.PositionStatus;
using IGAPI.Dtos.Project;
using IGAPI.Dtos.Rol;
using IGAPI.Dtos.SubRol;

namespace IGAPI.Dtos.Position;

public class PositionLazyResponseDto
{
    public int Id { get; set; }
    public ProjectResponseDto Project { get; set; }
    public AreaResponseDto Area { get; set; }
    public RolResponseDto Rol { get; set; }
    public SubRolResponseDto SubRol { get; set; }
    public LocalizationResponseDto Localization { get; set; }
    public PositionStatusResponseDto Status { get; set; }
    public string Description { get; set; }
    public int Vacancies { get; set; }
    [DataType(DataType.Date)]
    public DateTime CreationDate { get; set; }
    [DataType(DataType.Date)]
    public DateTime? ClosingDate { get; set; }
    [DataType(DataType.Date)]
    public DateTime LastUpdate { get; set; }
}