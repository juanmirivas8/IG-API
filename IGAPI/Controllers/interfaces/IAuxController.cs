using IGAPI.Dtos;
using IGAPI.Dtos.Project;
using Microsoft.AspNetCore.Mvc;

namespace IGAPI.Controllers.Interfaces;

public interface IAuxController
{
    Task<ActionResult<Response<ProjectFullResponse>>> PostProject([FromBody]ProjectPostRequestDto project);
    Task<ActionResult<Response<List<ProjectFullResponse>>>> GetProjects(); 
    
    Task<ActionResult<Response<ProjectFullResponse>>> UpdateProject([FromBody]ProjectUpdateRequestDto project);
    
    Task<ActionResult<Response<ProjectFullResponse>>> DeleteProject(int id);
    
    Task<ActionResult<Response<ProjectFullResponse>>> GetProjectById(int id);
}