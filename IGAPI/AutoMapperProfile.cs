using AutoMapper;
using IGAPI.Dtos.ApplicationStatus;
using IGAPI.Dtos.Area;
using IGAPI.Dtos.CandidateStatus;
using IGAPI.Dtos.Localization;
using IGAPI.Dtos.Position;
using IGAPI.Dtos.PositionStatus;
using IGAPI.Dtos.Project;
using IGAPI.Dtos.Rol;
using IGAPI.Dtos.SubRol;
using IGAPI.Models;

namespace IGAPI;

public class AutoMapperProfile:Profile
{
    public AutoMapperProfile()
    {
        //LookUps entities
        CreateMap<LocalizationEntity, LocalizationResponseDto>().ReverseMap();
        CreateMap<AreaEntity, AreaResponseDto>().ReverseMap();
        CreateMap<ProjectEntity, ProjectResponseDto>().ReverseMap();
        CreateMap<CandidateStatusEntity, CandidateStatusResponseDto>().ReverseMap();
        CreateMap<PositionStatusEntity, PositionStatusResponseDto>().ReverseMap();
        CreateMap<ApplicationStatusEntity, ApplicationStatusResponseDto>().ReverseMap();
        CreateMap<RolEntity, RolResponseDto>().ReverseMap();
        CreateMap<SubRolEntity, SubRolResponseDto>().ReverseMap();
        
        CreateMap<PositionPostDto, PositionEntity>().ReverseMap();
        CreateMap<PositionEntity, PositionResponseDto>();
    }
}