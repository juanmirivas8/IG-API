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
        
        if(!_unitOfWork.Context.Exists(positionEntity.Project)) _unitOfWork.Context.Projects.Attach(positionEntity.Project);
        if(!_unitOfWork.Context.Exists(positionEntity.Area)) _unitOfWork.Context.Areas.Attach(positionEntity.Area);
        if(!_unitOfWork.Context.Exists(positionEntity.Rol)) _unitOfWork.Context.Roles.Attach(positionEntity.Rol);
        if(!_unitOfWork.Context.Exists(positionEntity.SubRol)) _unitOfWork.Context.SubRoles.Attach(positionEntity.SubRol);
        if(!_unitOfWork.Context.Exists(positionEntity.Localization)) _unitOfWork.Context.Localizations.Attach(positionEntity.Localization);
        if(!_unitOfWork.Context.Exists(positionEntity.Status)) _unitOfWork.Context.PositionStatus.Attach(positionEntity.Status);
        
        
        //TODO: Validation of Position
        // Assignment of navigation properties
        foreach (var application in positionEntity.Applications)
        {
            if(!_unitOfWork.Context.Exists(application.Status)) _unitOfWork.Context.ApplicationStatus.Attach(application.Status);
            if(!_unitOfWork.Context.Exists(application.Candidate.Status)) _unitOfWork.Context.CandidateStatus.Attach(application.Candidate.Status);
            if(!_unitOfWork.Context.Exists(application.Candidate.ContactMethod)) _unitOfWork.Context.ContactMethods.Attach(application.Candidate.ContactMethod);
            application.Position = positionEntity;
        }
        

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