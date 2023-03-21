using IGAPI.Dtos.Project;
using IGAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace IGAPI.Controllers;

public interface IAuxController
{
    Task<ActionResult<Response<ProjectFullResponse>>> PostProject([FromBody]ProjectPostRequestDto project);
    Task<ActionResult<Response<List<ProjectFullResponse>>>> GetProjects(); 
}