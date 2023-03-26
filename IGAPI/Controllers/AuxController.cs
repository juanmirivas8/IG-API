using IGAPI.Controllers.Interfaces;
using IGAPI.Dtos.Project;
using IGAPI.Dtos;
using IGAPI.Repositories;
using IGAPI.Repositories.Interfaces;
using IGAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace IGAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class AuxController:ControllerBase,IAuxController
{
    private readonly IAuxService _auxService;
    private readonly IUnitOfWork _unitOfWork;
    public AuxController(IAuxService auxService, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _auxService = auxService;
    }
    
    [HttpPost("PostProject")]
    public async Task<ActionResult<Response<ProjectFullResponse>>> PostProject([FromBody] ProjectPostRequestDto project)
    {
        var response = await _auxService.PostProject(project);

        return response.Success ? Ok(response) : BadRequest(response);
    }

    [HttpGet("GetAllProjects")]
    public async Task<ActionResult<Response<List<ProjectFullResponse>>>> GetProjects()
    {
        var response = await _auxService.GetProjects();
        
        return response.Success ? Ok(response) : BadRequest(response);
    }

    [HttpPut("UpdateProject")]
    public async Task<ActionResult<Response<ProjectFullResponse>>> UpdateProject(ProjectUpdateRequestDto project)
    {
        var response = await _auxService.UpdateProject(project);
        
        return response.Success ? Ok(response) : BadRequest(response);
    }

    [HttpDelete("DeleteProject/{id}")]
    public async Task<ActionResult<Response<ProjectFullResponse>>> DeleteProject(int id)
    {
        var response = await _auxService.DeleteProject(id);
        return response.Success ? Ok(response) : BadRequest(response);
    }

    [HttpGet("GetProjectById/{id}")]
    public async Task<ActionResult<Response<ProjectFullResponse>>> GetProjectById(int id)
    {
        var response = await _auxService.GetProjectById(id);
        return response.Success ? Ok(response) : BadRequest(response);
    }
}