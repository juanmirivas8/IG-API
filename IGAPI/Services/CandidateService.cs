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
        await _unitOfWork.CandidateRepository.Add(candidateEntity);
        await _unitOfWork.SaveChangesAsync();
        var candidateResponseDto = _mapper.Map<CandidateResponseDto>(candidateEntity);

        return new Response<CandidateResponseDto>
        {
            Data = candidateResponseDto,
            Message = "Candidate Created succesfully",
            Success = true
        };
    }

    public async Task<Response<CandidateResponseDto>> Delete(CandidatePutDto candidateDto)
    {
        var candidateEntity = _mapper.Map<CandidateEntity>(candidateDto);
        var candidateDeleted = _mapper.Map<CandidateResponseDto>(candidateEntity);
        await _unitOfWork.CandidateRepository.Delete(candidateEntity);
        await _unitOfWork.SaveChangesAsync();

        return new Response<CandidateResponseDto>
        {
            Data = candidateDeleted,
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
                Success = false
            };
        }
    }

    public async Task<Response<CandidateResponseDto>> Update(CandidatePutDto candidateDto)
    {
        var candidateEntity = _mapper.Map<CandidateEntity>(candidateDto);
        await _unitOfWork.CandidateRepository.Update(candidateEntity);
        await _unitOfWork.SaveChangesAsync();
        var candidateResponse = _mapper.Map<CandidateResponseDto>(candidateEntity);

        return new Response<CandidateResponseDto>
        {
            Data = candidateResponse,
            Message = "Candidato actualizado con exito" ,
            Success = true
        };
    }
}