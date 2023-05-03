using AutoMapper;
using IGAPI.Dtos.Area;
using IGAPI.Dtos.Localization;
using IGAPI.Dtos.Project;
using IGAPI.Models;

namespace IGAPI;

public class AutoMapperProfile:Profile
{
    public AutoMapperProfile()
    {
        CreateMap<LocalizationEntity, LocalizationResponseDto>();
    }
}