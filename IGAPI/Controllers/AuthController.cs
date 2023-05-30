using Azure;
using IGAPI.Controllers.interfaces;
using IGAPI.Dtos.User;
using IGAPI.Repositories.Interfaces;
using IGAPI.Services.interfaces;
using Microsoft.AspNetCore.Authorization;
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
    [HttpPost("Register"),Authorize]
    public async Task<ActionResult<Response<bool>>> Register([FromBody]UserRequestDto userRequest)
    {
        var response = await _authService.Register(userRequest);
        await _unitOfWork.SaveChangesAsync();
        return response.Success? Ok(response): BadRequest(response);
    }

    [HttpPost("Login")]
    public async Task<ActionResult<Response<UserResponseDto>>> Login([FromBody]UserRequestDto userRequest)
    {
        var response = await _authService.Login(userRequest);
        return response.Success? Ok(response): BadRequest(response);
    }
}