using IGAPI.Dtos;
using IGAPI.Dtos.Application;
using IGAPI.Models;

namespace IGAPI.Services.interfaces;

public interface IApplicationService
{
    Task<Response<ApplicationResponseDto>> Create(ApplicationPostDto application);
    Task<Response<ApplicationResponseDto>> Update(ApplicationPutDto application);
    Task<Response<ApplicationResponseDto>> Delete(int id);
    Task<Response<IEnumerable<ApplicationResponseDto>>> GetAll();
    Task<Response<ApplicationResponseDto>> GetById(int id);
}