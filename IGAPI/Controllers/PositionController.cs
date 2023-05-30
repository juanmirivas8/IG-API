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
    //TODO: Implement authorization
    [HttpPost("Create")]
    public async Task<ActionResult<Response<PositionResponseDto>>> CreatePosition(PositionPostDto positionPostDto)
    {
        var response = await _positionService.CreatePosition(positionPostDto);
        return response.Success ? Ok(response) : BadRequest(response);
    }
}