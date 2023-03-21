using IGAPI.Dtos.Project;
using IGAPI.Models;
using IGAPI.Repositories;
using IGAPI.Services;
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
        var response =await _auxService.GetProjects();
        
        return response.Success ? Ok(response) : BadRequest(response);
    }
}