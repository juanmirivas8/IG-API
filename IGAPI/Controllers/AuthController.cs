using Azure;
using IGAPI.Controllers.interfaces;
using IGAPI.Dtos.User;
using IGAPI.Repositories.Interfaces;
using IGAPI.Services.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IGAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController: ControllerBase, IAuthController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthService _authService;
    public AuthController(IUnitOfWork unitOfWork, IAuthService authService)
    {
        _unitOfWork = unitOfWork;
        _authService = authService;
    }
    [HttpPost("register")]
    public async Task<ActionResult<Response<bool>>> Register([FromBody]UserDto user)
    {
        var response = await _authService.Register(user);
        await _unitOfWork.SaveChangesAsync();
        return response.Success? Ok(response): BadRequest(response);
    }
}