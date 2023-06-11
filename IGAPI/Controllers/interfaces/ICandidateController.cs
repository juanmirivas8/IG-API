using IGAPI.Dtos;
using IGAPI.Dtos.Candidate;
using Microsoft.AspNetCore.Mvc;

namespace IGAPI.Controllers.interfaces;

public interface ICandidateController
{
    Task<ActionResult<Response<CandidateResponseDto>>> Create(CandidatePostDto candidate);
    Task<ActionResult<Response<CandidateResponseDto>>> Update(CandidatePutDto candidate);
    Task<ActionResult<Response<CandidateResponseDto>>> Delete(int id);
    Task<ActionResult<Response<CandidateResponseDto>>> GetAll();
    Task<ActionResult<Response<CandidateResponseDto>>> GetById(int id);
}