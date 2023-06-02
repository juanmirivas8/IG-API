using System.ComponentModel.DataAnnotations;
using IGAPI.Dtos.Application;
using IGAPI.Dtos.Area;
using IGAPI.Dtos.Project;
using IGAPI.Dtos.Rol;
using IGAPI.Dtos.SubRol;
using IGAPI.Models;

namespace IGAPI.Dtos.Position;

public class PositionPostDto
{
    public ProjectResponseDto Project { get; set; }
    public AreaResponseDto Area { get; set; }
    public RolResponseDto Rol { get; set; }
    public SubRolResponseDto SubRol { get; set; }
    public LocalizationEntity Localization { get; set; }
    public PositionStatusEntity Status { get; set; }
    public string Description { get; set; }
    public int Vacancies { get; set; }
    [DataType(DataType.Date)]
    public DateTime CreationDate { get; set; }
    [DataType(DataType.Date)]
    public DateTime? ClosingDate { get; set; }
    [DataType(DataType.Date)]
    public DateTime LastUpdate { get; set; }
    public IEnumerable<ApplicationPostDto> Applications { get; set; }
}

