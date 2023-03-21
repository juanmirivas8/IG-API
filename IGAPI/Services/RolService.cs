using AutoMapper;
using IGAPI.Dtos.Rol;
using IGAPI.Models;
using IGWebAPI.Services;


namespace IGAPI.Services;

public class RolService : IRolService
{
    private readonly IMapper _mapper;

    public RolService(IMapper mapper)
    {
        _mapper = mapper;
    }
    private List<RolEntity> mockDB = new()
    {
        new RolEntity()
        {
            Id = 1,
            Description = "Admin"
        },
        new RolEntity()
        {
            Id = 2,
            Description = "User"
        }
    };

    public async Task<Response<RolFullGetResponseDto>> GetById(int id)
    {
        var rol = mockDB.FirstOrDefault(x => x.Id == id);
        
        if (rol is null)
        {
            return new Response<RolFullGetResponseDto>()
            {
                Success = false,
                Message = "Rol not found"
            };
        }
        else
        {
            return new Response<RolFullGetResponseDto>()
            {
                Data = _mapper.Map<RolFullGetResponseDto>(rol),
                Success = true,
                Message = "Rol found"
            };
        }
    }
    
}