using IGAPI.Dtos.Area;

namespace IGAPI.Dtos.Project;

public class ProjectPostRequestDto
{
    public String Name { get; set; }
    public List<AreaPostRequestDto> Areas { get; set; }
}