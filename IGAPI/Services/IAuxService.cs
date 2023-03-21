
using IGAPI.Dtos.Project;
using IGAPI.Models;

namespace IGAPI.Services;

public interface IAuxService
{
    Task<Response<ProjectFullResponse>> PostProject(ProjectPostRequestDto project);
}