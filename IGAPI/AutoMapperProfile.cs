using AutoMapper;
using IGAPI.Dtos.Project;
using IGAPI.Dtos.Rol;
using IGAPI.Models;

namespace IGAPI;

public class AutoMapperProfile:Profile
{
    public AutoMapperProfile()
    {
        // Add as many of these lines as you need to map your objects
        CreateMap<RolEntity, RolFullGetResponseDto>();
        CreateMap<ProjectPostRequestDto, ProjectEntity>();
        CreateMap<ProjectEntity, ProjectFullResponse>();
    }
}