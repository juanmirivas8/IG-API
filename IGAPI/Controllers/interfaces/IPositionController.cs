using IGAPI.Dtos;
using IGAPI.Dtos.Position;
using Microsoft.AspNetCore.Mvc;

namespace IGAPI.Controllers.interfaces;

public interface IPositionController
{
    Task<ActionResult<Response<PositionResponseDto>>> CreatePosition(PositionPostDto positionPostDto);
    Task<ActionResult<Response<PositionResponseDto>>> Delete(int id);
    Task<ActionResult<Response<PositionResponseDto>>> Update(PositionPutDto position);
    Task<ActionResult<Response<PositionResponseDto>>> GetAll();
    Task<ActionResult<Response<PositionResponseDto>>> GetById(int id);
}