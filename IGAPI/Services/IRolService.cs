
using IGAPI.Dtos.Rol;
using IGAPI.Models;

namespace IGWebAPI.Services;

public interface IRolService
{
    Task<Response<RolFullGetResponseDto>> GetById(int id);
}