using AutoMapper;
using IGAPI.Dtos;
using IGAPI.Dtos.Position;
using IGAPI.Models;
using IGAPI.Repositories.Interfaces;
using IGAPI.Services.interfaces;

namespace IGAPI.Services;

public class PositionService:Service,IPositionService
{
    public PositionService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork,mapper)
    {
    }


    public async Task<Response<PositionResponseDto>> CreatePosition(PositionPostDto positionPostDto)
    {
        var positionEntity = _mapper.Map<PositionEntity>(positionPostDto);
        _unitOfWork.Context.Projects.Attach(positionEntity.Project);
        _unitOfWork.Context.Areas.Attach(positionEntity.Area);
        _unitOfWork.Context.Roles.Attach(positionEntity.Rol);
        _unitOfWork.Context.SubRoles.Attach(positionEntity.SubRol);
        _unitOfWork.Context.Localizations.Attach(positionEntity.Localization);
        _unitOfWork.Context.PositionStatus.Attach(positionEntity.Status);
        // Validate positionEntity
        var entityFromDB = await _unitOfWork.PositionRepository.Add(positionEntity);
        await _unitOfWork.SaveChangesAsync();
        
        var positionResponseDto = _mapper.Map<PositionResponseDto>(entityFromDB);
        return new Response<PositionResponseDto>
        {
            Data = positionResponseDto,
            Message = "Position created successfully",
            Success = true
        };
    }
}