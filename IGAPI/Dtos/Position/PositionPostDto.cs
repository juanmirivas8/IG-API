using System.ComponentModel.DataAnnotations;
using IGAPI.Dtos.Application;
using IGAPI.Models;

namespace IGAPI.Dtos.Position;

public class PositionPostDto
{
    public ProjectEntity Project { get; set; }
    public AreaEntity Area { get; set; }
    public RolEntity Rol { get; set; }
    public SubRolEntity SubRol { get; set; }
    public LocalizationEntity Localization { get; set; }
    public PositionStatusEntity Status { get; set; }
    public string Description { get; set; }
    public int Vacancies { get; set; }
    [DataType(DataType.Date)]
    public DateTime CreationDate { get; set; }
    [DataType(DataType.Date)]
    public DateTime ClosingDate { get; set; }
    [DataType(DataType.Date)]
    public DateTime LastUpdate { get; set; }
    public IEnumerable<ApplicationPostDto> Applications { get; set; }
}

