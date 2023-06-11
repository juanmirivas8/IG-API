using IGAPI.Controllers.interfaces;
using IGAPI.Dtos;
using IGAPI.Dtos.Candidate;
using IGAPI.Services.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IGAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class CandidateController:ControllerBase,ICandidateController
{

    private readonly ICandidateService _candidateService;

    public CandidateController(ICandidateService candidateService)
    {
        _candidateService= candidateService;
    }
    [HttpPost,Authorize]
    [Route("Create")]
    public async Task<ActionResult<Response<CandidateResponseDto>>> Create([FromBody] CandidatePostDto candidate)
    {
        var response = await _candidateService.Create(candidate);
        return response.Success ? Ok(response) : BadRequest(response);
    }

    [HttpPut,Authorize]
    [Route("Update")]
    public async Task<ActionResult<Response<CandidateResponseDto>>> Update([FromBody] CandidatePutDto candidate)
    {
        var response = await _candidateService.Update(candidate);
        return response.Success ? Ok(response) : BadRequest(response);
    }

    [HttpDelete,Authorize]
    [Route("Delete/{id}")]
    public async Task<ActionResult<Response<CandidateResponseDto>>> Delete(int id)
    {
        var response = await _candidateService.Delete(id);
        return response.Success ? Ok(response) : BadRequest(response);
    }

    [HttpGet,Authorize]
    [Route("GetAll")]
    public async Task<ActionResult<Response<CandidateResponseDto>>> GetAll()
    {
        var response = await _candidateService.GetAll();
        return response.Success ? Ok(response) : BadRequest(response);
    }

    [HttpGet,Authorize]
    [Route("GetById/{id}")]
    public async Task<ActionResult<Response<CandidateResponseDto>>> GetById(int id)
    {
        var response = await _candidateService.GetById(id);
        return response.Success ? Ok(response) : BadRequest(response);
    }
}