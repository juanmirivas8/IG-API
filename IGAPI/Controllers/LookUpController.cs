using IGAPI.Controllers.interfaces;
using IGAPI.Dtos;
using IGAPI.Dtos.Localization;
using IGAPI.Repositories.Interfaces;
using IGAPI.Services.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IGAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class LookUpController: ControllerBase,ILookUpController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILookUpService _lookUpService;

    public LookUpController(IUnitOfWork unitOfWork, ILookUpService lookUpService)
    {
        _unitOfWork = unitOfWork;
        _lookUpService = lookUpService;
    }
    
    [HttpGet("GetAllLocalizations")]
    public async Task<ActionResult<Response<IEnumerable<LocalizationResponseDto>>>> GetAllLocalizations()
    {
        var response = await _lookUpService.GetAllLocalizations();

        return response.Success ? Ok(response) : BadRequest(response);
    }
}