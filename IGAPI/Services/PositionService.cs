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
        
        //TODO:add any validation necessary and return error
        
        positionEntity.Area = await _unitOfWork.AreaRepository.GetById(positionPostDto.Area.Id);
        positionEntity.Project = await _unitOfWork.ProjectRepository.GetById(positionPostDto.Project.Id);
        positionEntity.Rol = await _unitOfWork.RolRepository.GetById(positionPostDto.Rol.Id);
        positionEntity.SubRol = await _unitOfWork.SubRolRepository.GetById(positionPostDto.SubRol.Id);
        positionEntity.Localization = await _unitOfWork.LocalizationRepository.GetById(positionPostDto.Localization.Id);
        positionEntity.Status = await _unitOfWork.PositionStatusRepository.GetById(positionPostDto.Status.Id);
        
        //TODO:check if some of the lookups are null and return error
        
        foreach (var application in positionEntity.Applications)
        {
            if (application.Candidate.Id != 0)
            {
                application.Candidate = await _unitOfWork.CandidateRepository.GetById(application.Candidate.Id);
                //TODO:Check if is null and return error candidate that it was supposed to be created not found
            }
            else
            {
                application.Candidate.Status = await _unitOfWork.CandidateStatusRepository.GetById(application.Candidate.Status.Id);
                application.Candidate.ContactMethod = await _unitOfWork.ContactMethodRepository.GetById(application.Candidate.ContactMethod.Id);
                //TODO:check if some of the lookups are null and return error
            }
            application.Status = await _unitOfWork.ApplicationStatusRepository.GetById(application.Status.Id);
            //TODO:check if some of the lookups are null and return error
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