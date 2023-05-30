using IGAPI.Dtos;
using IGAPI.Dtos.Position;

namespace IGAPI.Services.interfaces;

public interface IPositionService
{
    Task<Response<PositionResponseDto>> CreatePosition(PositionPostDto positionPostDto);
    
}