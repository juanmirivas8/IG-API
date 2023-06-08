using AutoMapper;
using IGAPI.Dtos;
using IGAPI.Dtos.Position;
using IGAPI.Models;
using IGAPI.Repositories.Interfaces;
using IGAPI.Services.interfaces;
using Microsoft.EntityFrameworkCore;

namespace IGAPI.Services;

public class PositionService:Service,IPositionService
{
    public PositionService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork,mapper)
    {
    }
    
    public async Task<Response<PositionResponseDto>> CreatePosition(PositionPostDto positionPostDto)
    {
        var positionEntity = _mapper.Map<PositionEntity>(positionPostDto);
        
        foreach (var application in positionEntity.Applications)
        {
            application.Status = null;
            application.Position = positionEntity;
        }
        var entityFromInsert = await _unitOfWork.PositionRepository.Add(positionEntity);
        await _unitOfWork.SaveChangesAsync();
        
        var entityFromDB = await _unitOfWork.PositionRepository.GetById(entityFromInsert.Id);
        var positionResponseDto = _mapper.Map<PositionResponseDto>(entityFromInsert);
        
        return new Response<PositionResponseDto>
        {
            Data = positionResponseDto,
            Message = "Position created successfully",
            Success = true
        };
    }
}