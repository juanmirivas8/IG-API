using AutoMapper;
using IGAPI.Dtos;
using IGAPI.Dtos.Candidate;
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
        entityFromInsert.Area = await _unitOfWork.AreaRepository.GetById(entityFromInsert.AreaId);
        entityFromInsert.Localization = await _unitOfWork.LocalizationRepository.GetById(entityFromInsert.LocalizationId);
        entityFromInsert.Rol = await _unitOfWork.RolRepository.GetById(entityFromInsert.RolId);
        entityFromInsert.SubRol = await _unitOfWork.SubRolRepository.GetById(entityFromInsert.SubRolId);

        var positionResponseDto = _mapper.Map<PositionResponseDto>(entityFromInsert);
        
        return new Response<PositionResponseDto>
        {
            Data = positionResponseDto,
            Message = "Position created successfully",
            Success = true
        };
    }

    public async Task<Response<PositionResponseDto>> Delete(int id)
    {
        var position = _unitOfWork.PositionRepository.GetById(id);
        var positionEntity = _mapper.Map<PositionEntity>(position);
        await _unitOfWork.PositionRepository.Delete(positionEntity);
        await _unitOfWork.SaveChangesAsync();
         return new Response<PositionResponseDto> 
         { 
             Data = _mapper.Map<PositionResponseDto>(positionEntity),
             Message = "Posicion eliminada correctamente",
             Success = true
         };
    }

    public async Task<Response<IEnumerable<PositionResponseDto>>>GetAll()
    {
        var list = await _unitOfWork.PositionRepository.GetAll();
        if (list.Any())
        {
            return new Response<IEnumerable<PositionResponseDto>>
            {
                Data = _mapper.Map<IEnumerable<PositionResponseDto>>(list),
                Message = "Operacion exitosa",
                Success = true
            };
        }
        else
        {
            return new Response<IEnumerable<PositionResponseDto>>
            {
                Message = "Operacion fallida",
                Success = false
            };
        }
    }

    public Task<Response<PositionResponseDto>> GetById()
    {
        throw new NotImplementedException();
    }

    public async Task<Response<PositionResponseDto>> Update(PositionPutDto position)
    {
        var positionEntity = _mapper.Map<PositionEntity>(position);
        var positionUpdated = await _unitOfWork.PositionRepository.Update(positionEntity);
        await _unitOfWork.SaveChangesAsync();
        positionUpdated.Area = await _unitOfWork.AreaRepository.GetById(positionUpdated.AreaId);
        positionUpdated.Localization = await _unitOfWork.LocalizationRepository.GetById(positionUpdated.LocalizationId);
        positionUpdated.Rol = await _unitOfWork.RolRepository.GetById(positionUpdated.RolId);
        positionUpdated.SubRol = await _unitOfWork.SubRolRepository.GetById(positionUpdated.SubRolId);
        return new Response<PositionResponseDto>
        {
            Data = _mapper.Map<PositionResponseDto>(positionUpdated),
            Message = "Posicion actualizada correctamente",
            Success = true
        };
    }
}