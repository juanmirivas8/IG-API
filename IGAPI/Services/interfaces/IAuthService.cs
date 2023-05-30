using IGAPI.Dtos;
using IGAPI.Dtos.User;

namespace IGAPI.Services.interfaces;

public interface IAuthService
{ 
    Task<Response<bool>> Register(UserRequestDto request);
    Task<Response<UserResponseDto>> Login(UserRequestDto request);
}