using IGAPI.Dtos;
using IGAPI.Dtos.Position;

namespace IGAPI.Services.interfaces;

public interface IPositionService
{
    Task<Response<PositionResponseDto>> CreatePosition(PositionPostDto positionPostDto);
    Task<Response<PositionResponseDto>> Update(PositionPutDto position);
    Task<Response<PositionResponseDto>> Delete(int id);
    Task<Response<IEnumerable<PositionResponseDto>>> GetAll();
    Task<Response<PositionResponseDto>> GetById();
    
}