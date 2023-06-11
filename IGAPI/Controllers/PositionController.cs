using IGAPI.Controllers.interfaces;
using IGAPI.Dtos;
using IGAPI.Dtos.Position;
using IGAPI.Services.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IGAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class PositionController:ControllerBase,IPositionController
{
    private readonly IPositionService _positionService;
    public PositionController(IPositionService positionService)
    {
        _positionService = positionService;
    }
    //TODO: Implement authorization
    [HttpPost("Create")]
    public async Task<ActionResult<Response<PositionResponseDto>>> CreatePosition([FromBody] PositionPostDto positionPostDto)
    {
        var response = await _positionService.CreatePosition(positionPostDto);
        return response.Success ? Ok(response) : BadRequest(response);
    }

    [HttpDelete]
    [Route("Delete/{id}")]
    public async Task<ActionResult<Response<PositionResponseDto>>> Delete(int id)
    {
        var response = await _positionService.Delete(id);
        return response.Success ? Ok(response) : BadRequest(response);
    }

    [HttpGet]
    [Route("GetAll")]
    public async Task<ActionResult<Response<PositionResponseDto>>> GetAll()
    {
        var response = await _positionService.GetAll();
        return response.Success ? Ok(response) : BadRequest(response);
    }

    [HttpPut]
    [Route("Update")]
    public async Task<ActionResult<Response<PositionResponseDto>>> Update([FromBody] PositionPutDto positionPostDto)
    {
        var response = await _positionService.Update(positionPostDto);
        return response.Success ? Ok(response) : BadRequest(response);
    }
}