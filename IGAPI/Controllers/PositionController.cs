using IGAPI.Controllers.interfaces;
using IGAPI.Dtos;
using IGAPI.Dtos.Position;
using IGAPI.Services.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


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
    [HttpPost,Authorize]
    [Route("Create")]
    public async Task<ActionResult<Response<PositionResponseDto>>> CreatePosition([FromBody] PositionPostDto positionPostDto)
    {
        var response = await _positionService.CreatePosition(positionPostDto);
        return response.Success ? Ok(response) : BadRequest(response);
    }

    [HttpDelete,Authorize]
    [Route("Delete/{id}")]
    public async Task<ActionResult<Response<PositionResponseDto>>> Delete(int id)
    {
        var response = await _positionService.Delete(id);
        return response.Success ? Ok(response) : BadRequest(response);
    }

    [HttpGet,Authorize]
    [Route("GetAll")]
    public async Task<ActionResult<Response<PositionResponseDto>>> GetAll()
    {
        var response = await _positionService.GetAll();
        return response.Success ? Ok(response) : BadRequest(response);
    }

    [HttpGet,Authorize]
    [Route("GetById/{id}")]
    public async Task<ActionResult<Response<PositionResponseDto>>> GetById(int id)
    {
        var response = await _positionService.GetById(id);
        return response.Success ? Ok(response) : BadRequest(response);
    }

    [HttpPut,Authorize]
    [Route("Update")]
    public async Task<ActionResult<Response<PositionResponseDto>>> Update([FromBody] PositionPutDto positionPostDto)
    {
        var response = await _positionService.Update(positionPostDto);
        return response.Success ? Ok(response) : BadRequest(response);
    }
}