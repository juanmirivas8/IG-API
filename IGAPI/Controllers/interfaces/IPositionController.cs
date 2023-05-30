using IGAPI.Dtos;
using IGAPI.Dtos.Position;
using Microsoft.AspNetCore.Mvc;

namespace IGAPI.Controllers.interfaces;

public interface IPositionController
{
    Task<ActionResult<Response<PositionResponseDto>>> CreatePosition(PositionPostDto positionPostDto);
}