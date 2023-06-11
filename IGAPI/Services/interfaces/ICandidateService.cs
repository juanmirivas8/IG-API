
using IGAPI.Dtos;
using IGAPI.Dtos.Candidate;

namespace IGAPI.Services.interfaces;

public interface ICandidateService
{
    Task<Response<CandidateResponseDto>> Create(CandidatePostDto candidateDto);
    Task<Response<CandidateResponseDto>> Update(CandidatePutDto candidateDto);
    Task<Response<CandidateResponseDto>> Delete(int id);
    Task<Response<IEnumerable<CandidateResponseDto>>> GetAll();
    Task<Response<CandidateResponseDto>> GetById(int id);
}