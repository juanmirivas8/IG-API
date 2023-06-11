using IGAPI.Dtos;
using IGAPI.Dtos.Application;
using Microsoft.AspNetCore.Mvc;

namespace IGAPI.Controllers.interfaces;

public interface IApplicationController
{
    Task<ActionResult<Response<ApplicationResponseDto>>> Create(ApplicationPostDto application);
    Task<ActionResult<Response<ApplicationResponseDto>>> Update(ApplicationPutDto application);
    Task<ActionResult<Response<ApplicationResponseDto>>> Delete(int id);
    Task<ActionResult<Response<ApplicationResponseDto>>> GetAll();
    Task<ActionResult<Response<ApplicationResponseDto>>> GetById(int id);
}