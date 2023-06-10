
using IGAPI.Dtos;
using IGAPI.Dtos.Candidate;

namespace IGAPI.Services.interfaces;

public interface ICandidateService
{
    Task<Response<CandidateResponseDto>> Create(CandidatePostDto candidateDto);
    Task<Response<CandidateResponseDto>> Update(CandidatePutDto candidateDto);
    Task<Response<CandidateResponseDto>> Delete(CandidatePutDto candidateDto);
    Task<Response<IEnumerable<CandidateResponseDto>>> GetAll();
}