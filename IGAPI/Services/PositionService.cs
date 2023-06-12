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
        
        foreach (var application in positionEntity.Applications)
        {
            application.Status = null;
            application.Position = positionEntity;
        }
        var entityFromInsert = await _unitOfWork.PositionRepository.Add(positionEntity);
        await _unitOfWork.SaveChangesAsync();

        var positionFromDb = await _unitOfWork.PositionRepository.GetById(entityFromInsert.Id);
        var positionResponseDto = _mapper.Map<PositionResponseDto>(positionFromDb);
        
        return new Response<PositionResponseDto>
        {
            Data = positionResponseDto,
            Message = "Position created successfully",
            Success = true
        };
    }

    public async Task<Response<PositionResponseDto>> Delete(int id)
    {
        var position = await _unitOfWork.PositionRepository.GetById(id);
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
                Success = true
            };
        }
    }

    public async Task<Response<PositionResponseDto>> GetById(int id)
    {
        var position = await _unitOfWork.PositionRepository.GetById(id);
        
        if (position != null)
        {
            return new Response<PositionResponseDto>
            {
                Data = _mapper.Map<PositionResponseDto>(position),
                Message = "Position found",
                Success = true
            };
        }
        else
        {
            return new Response<PositionResponseDto>
            {
                Message = "Position not found",
                Success = false
            };
        }
    }

    public async Task<Response<PositionResponseDto>> Update(PositionPutDto position)
    {
        var positionEntity = _mapper.Map<PositionEntity>(position);
        var positionUpdated = await _unitOfWork.PositionRepository.Update(positionEntity);
        await _unitOfWork.SaveChangesAsync();
        var entityFromDB = await _unitOfWork.PositionRepository.GetById(positionUpdated.Id);
   
        return new Response<PositionResponseDto>
        {
            Data = _mapper.Map<PositionResponseDto>(entityFromDB),
            Message = "Position updated successfully",
            Success = true
        };
    }
}