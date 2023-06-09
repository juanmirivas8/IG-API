using AutoMapper;
using IGAPI.Dtos;
using IGAPI.Dtos.Candidate;
using IGAPI.Models;
using IGAPI.Repositories;
using IGAPI.Repositories.Interfaces;
using IGAPI.Services.interfaces;
using Microsoft.AspNetCore.Http.HttpResults;

namespace IGAPI.Services;

public class CandidateService :Service, ICandidateService
{
    public CandidateService(IUnitOfWork unitOfWork, IMapper mapper): base(unitOfWork, mapper)
    {
    }

    public async Task<Response<CandidateResponseDto>> Create(CandidatePostDto candidateDto)
    {
        var candidateEntity = _mapper.Map<CandidateEntity>(candidateDto);
        var candidateCreated = await _unitOfWork.CandidateRepository.Add(candidateEntity);
        await _unitOfWork.SaveChangesAsync();
        
        var candidateFromDB = await _unitOfWork.CandidateRepository.GetById(candidateCreated.Id);
        return new Response<CandidateResponseDto>
        {
            Data = _mapper.Map<CandidateResponseDto>(candidateFromDB),
            Message = "Candidate Created succesfully",
            Success = true
        };
    }

    public async Task<Response<CandidateResponseDto>> Delete(int id)
    {
        var candidateDto = await _unitOfWork.CandidateRepository.GetById(id);
        var candidateEntity = _mapper.Map<CandidateEntity>(candidateDto);
        var candidateDeleted = await _unitOfWork.CandidateRepository.Delete(candidateEntity);
        await _unitOfWork.SaveChangesAsync();

        return new Response<CandidateResponseDto>
        {
            Data = _mapper.Map<CandidateResponseDto>(candidateDeleted),
            Message = "Candidato eliminado correctamente",
            Success = true
        };
    }

    public async Task<Response<IEnumerable<CandidateResponseDto>>> GetAll()
    {
        var list = await _unitOfWork.CandidateRepository.GetAll();
        if (list.Any())
        {
            return new Response<IEnumerable<CandidateResponseDto>>
            {
                Data = _mapper.Map<IEnumerable<CandidateResponseDto>>(list),
                Message = "Operacion exitosa",
                Success = true
            };
        }
        else
        {
            return new Response<IEnumerable<CandidateResponseDto>>
            {
                Message = "Operacion fallida",
                Success = true
            };
        }
    }

    public async Task<Response<CandidateResponseDto>> GetById(int id)
    {
        var candidate = await _unitOfWork.CandidateRepository.GetById(id);
        return new Response<CandidateResponseDto>
        {
            Data = _mapper.Map<CandidateResponseDto>(candidate),
            Message = "Success",
            Success = true
        };
    }

    public async Task<Response<CandidateResponseDto>> Update(CandidatePutDto candidateDto)
    {
        var candidateEntity = _mapper.Map<CandidateEntity>(candidateDto);
        var candidateUpdated = await _unitOfWork.CandidateRepository.Update(candidateEntity);
        await _unitOfWork.SaveChangesAsync();
      
        var candidateFromDB = await _unitOfWork.CandidateRepository.GetById(candidateUpdated.Id);

        return new Response<CandidateResponseDto>
        {
            Data = _mapper.Map<CandidateResponseDto>(candidateFromDB),
            Message = "Candidato actualizado con exito" ,
            Success = true
        };
    }
}