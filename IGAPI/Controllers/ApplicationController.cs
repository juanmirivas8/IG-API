using AutoMapper.Configuration.Conventions;
using IGAPI.Controllers.interfaces;
using IGAPI.Dtos;
using IGAPI.Dtos.Application;
using IGAPI.Services.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IGAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ApplicationController: ControllerBase,IApplicationController
{
    private readonly IApplicationService _applicationService;
    public ApplicationController(IApplicationService applicationService) 
    {
        _applicationService = applicationService;
    }

    [HttpPost,Authorize]
    [Route("Create")]
    public async Task<ActionResult<Response<ApplicationResponseDto>>> Create([FromBody] ApplicationPostDto application)
    {
        var response = await _applicationService.Create(application);
        return response.Success ? Ok(response) : BadRequest(response);
    }

    [HttpDelete,Authorize]
    [Route("Delete/{id}")]
    public async Task<ActionResult<Response<ApplicationResponseDto>>> Delete(int id)
    {
        var response = await _applicationService.Delete(id);
        return response.Success ? Ok(response) : BadRequest(response);
    }

    [HttpPut,Authorize]
    [Route("Update")]
    public async Task<ActionResult<Response<ApplicationResponseDto>>> Update([FromBody] ApplicationPutDto application)
    {
        var response = await _applicationService.Update(application);
        return response.Success ? Ok(response) : BadRequest(response);
    }

    [HttpGet,Authorize]
    [Route("GetAll")]
    public async Task<ActionResult<Response<ApplicationResponseDto>>> GetAll()
    {
        var response = await _applicationService.GetAll();
        return response.Success ? Ok(response) : BadRequest(response);
    }

    [HttpGet,Authorize]
    [Route("GetById/{id}")]
    public async Task<ActionResult<Response<ApplicationResponseDto>>> GetById(int id)
    {
        var response = await _applicationService.GetById(id);
        return response.Success ? Ok(response) : BadRequest(response);
    }
}