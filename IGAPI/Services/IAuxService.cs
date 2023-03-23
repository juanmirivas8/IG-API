
using IGAPI.Dtos.Project;
using IGAPI.Models;

namespace IGAPI.Services;

public interface IAuxService
{
    Task<Response<ProjectFullResponse>> PostProject(ProjectPostRequestDto project);
    Task<Response<List<ProjectFullResponse>>> GetProjects();
    
    Task<Response<ProjectFullResponse>> UpdateProject(ProjectUpdateRequestDto project);
    
    Task<Response<ProjectFullResponse>> DeleteProject(int id);
    
    Task<Response<ProjectFullResponse>> GetProjectById(int id);
}