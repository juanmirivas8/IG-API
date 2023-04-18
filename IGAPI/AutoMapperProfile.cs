using AutoMapper;
using IGAPI.Dtos.Area;
using IGAPI.Dtos.Project;
using IGAPI.Models;

namespace IGAPI;

public class AutoMapperProfile:Profile
{
    public AutoMapperProfile()
    {
        // Add as many of these lines as you need to map your objects
        CreateMap<AreaPostRequestDto, AreaEntity>();
        CreateMap<AreaEntity, AreaFullResponseDto>();
        CreateMap<ProjectPostRequestDto, ProjectEntity>();
        CreateMap<ProjectEntity, ProjectFullResponse>();
        CreateMap<ProjectUpdateRequestDto, ProjectEntity>();
        
    }
}