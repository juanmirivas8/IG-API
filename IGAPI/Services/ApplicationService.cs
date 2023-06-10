using AutoMapper;
using IGAPI.Dtos;
using IGAPI.Dtos.Application;
using IGAPI.Models;
using IGAPI.Repositories.Interfaces;
using IGAPI.Services.interfaces;

namespace IGAPI.Services;

public class ApplicationService: Service,IApplicationService
{
    public ApplicationService(IUnitOfWork unitOfWork, IMapper mapper):base(unitOfWork, mapper) 
    {

    }

    public async Task<Response<ApplicationResponseDto>> Create(ApplicationPostDto application)
    {
        var applicationEntity = _mapper.Map<ApplicationEntity>(application);
        await _unitOfWork.ApplicationRepository.Add(applicationEntity);
        await _unitOfWork.SaveChangesAsync();
        return new Response<ApplicationResponseDto>
        {
            Data = _mapper.Map<ApplicationResponseDto>(applicationEntity),
            Message = "Applicacion realizada con exito",
            Success = true
        };
    }

    public async Task<Response<ApplicationResponseDto>> Delete(ApplicationPutDto application)
    {
        var applicationEntity = _mapper.Map<ApplicationEntity>(application);
        await _unitOfWork.ApplicationRepository.Delete(applicationEntity);
        await _unitOfWork.SaveChangesAsync();
        return new Response<ApplicationResponseDto>
        {
            Data = _mapper.Map<ApplicationResponseDto>(application),
            Message = "Applicacion eliminada correctamente",
            Success = true
        };
    }

    public async Task<Response<IEnumerable<ApplicationResponseDto>>> GetAll()
    {
        var list  = await _unitOfWork.ApplicationRepository.GetAll();
        if (list.Any())
        {
            return new Response<IEnumerable<ApplicationResponseDto>>
            {
                Data = _mapper.Map<IEnumerable<ApplicationResponseDto>>(list),
                Message = "Operacion exitosa",
                Success = true
            };
        }
        else
        {
            return new Response<IEnumerable<ApplicationResponseDto>>
            {
                Message = "Operacion fallida",
                Success = false
            };
        }
       

    }

    public async Task<Response<ApplicationResponseDto>> Update(ApplicationPutDto application)
    {
        var applicationEntity = _mapper.Map<ApplicationEntity>(application);
        await _unitOfWork.ApplicationRepository.Update(applicationEntity);
        await _unitOfWork.SaveChangesAsync();
        return new Response<ApplicationResponseDto>
        {
            Data = _mapper.Map<ApplicationResponseDto>(applicationEntity),
            Message = "Aplicacion actualizada con exito",
            Success = true
        };
    }

}