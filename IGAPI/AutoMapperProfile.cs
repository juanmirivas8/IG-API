using AutoMapper;
using IGAPI.Dtos.Application;
using IGAPI.Dtos.ApplicationStatus;
using IGAPI.Dtos.Area;
using IGAPI.Dtos.Candidate;
using IGAPI.Dtos.CandidateStatus;
using IGAPI.Dtos.ContactMethod;
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
        CreateMap<ContactMethodEntity, ContactMethodResponseDto>().ReverseMap();

        CreateMap<PositionPostDto, PositionEntity>()
            .ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.Project.Id))
            .ForMember(dest => dest.AreaId, opt => opt.MapFrom(src => src.Area.Id))
            .ForMember(dest => dest.RolId, opt => opt.MapFrom(src => src.Rol.Id))
            .ForMember(dest => dest.SubRolId, opt => opt.MapFrom(src => src.SubRol.Id))
            .ForMember(dest => dest.LocalizationId, opt => opt.MapFrom(src => src.Localization.Id))
            .ForMember(dest => dest.StatusId, opt => opt.MapFrom(src => src.Status.Id))
            .ForMember(dest => dest.Localization, opt => opt.Ignore())
            .ForMember(dest => dest.Area, opt => opt.Ignore())
            .ForMember(dest => dest.Project, opt => opt.Ignore())
            .ForMember(dest => dest.Rol, opt => opt.Ignore())
            .ForMember(dest => dest.SubRol, opt => opt.Ignore())
            .ForMember(dest => dest.Status, opt => opt.Ignore());
        CreateMap<PositionPutDto, PositionEntity>()
            .ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.Project.Id))
            .ForMember(dest => dest.AreaId, opt => opt.MapFrom(src => src.Area.Id))
            .ForMember(dest => dest.RolId, opt => opt.MapFrom(src => src.Rol.Id))
            .ForMember(dest => dest.SubRolId, opt => opt.MapFrom(src => src.SubRol.Id))
            .ForMember(dest => dest.LocalizationId, opt => opt.MapFrom(src => src.Localization.Id))
            .ForMember(dest => dest.StatusId, opt => opt.MapFrom(src => src.Status.Id))
            .ForMember(dest => dest.Localization, opt => opt.Ignore())
            .ForMember(dest => dest.Area, opt => opt.Ignore())
            .ForMember(dest => dest.Project, opt => opt.Ignore())
            .ForMember(dest => dest.Rol, opt => opt.Ignore())
            .ForMember(dest => dest.SubRol, opt => opt.Ignore())
            .ForMember(dest => dest.Status, opt => opt.Ignore());
        CreateMap<PositionEntity, PositionResponseDto>();
        CreateMap<PositionEntity, PositionLazyResponseDto>();
        
        CreateMap<ApplicationPostDto, ApplicationEntity>()
            .ForMember(dest => dest.CandidateId, opt => opt.MapFrom(src => src.Candidate.Id))
            .ForMember(dest => dest.PositionId, opt => opt.MapFrom(src => src.Position.Id))
            .ForMember(dest => dest.StatusId, opt => opt.MapFrom(src => src.Status.Id))
            .ForMember(dest => dest.Status, opt => opt.Ignore());
        CreateMap<ApplicationPutDto, ApplicationEntity>()
            .ForMember(dest => dest.CandidateId, opt => opt.MapFrom(src => src.Candidate.Id))
            .ForMember(dest => dest.PositionId, opt => opt.MapFrom(src => src.Position.Id))
            .ForMember(dest => dest.StatusId, opt => opt.MapFrom(src => src.Status.Id))
            .ForMember(dest => dest.Status, opt => opt.Ignore());
        CreateMap<ApplicationEntity, ApplicationResponseDto>();
           
        CreateMap<CandidatePostDto, CandidateEntity>()
            .ForMember(dest => dest.StatusId, opt => opt.MapFrom(src => src.Status.Id))
            .ForMember(dest => dest.ContactMethodId, opt => opt.MapFrom(src => src.ContactMethod.Id))
            .ForMember(dest => dest.ContactMethod, opt => opt.Ignore())
            .ForMember(dest => dest.Status, opt => opt.Ignore());
        CreateMap<CandidatePutDto, CandidateEntity>()
            .ForMember(dest => dest.StatusId, opt => opt.MapFrom(src => src.Status.Id))
            .ForMember(dest => dest.ContactMethodId, opt => opt.MapFrom(src => src.ContactMethod.Id))
            .ForMember(dest => dest.ContactMethod, opt => opt.Ignore())
            .ForMember(dest => dest.Status, opt => opt.Ignore());
        CreateMap<CandidateEntity, CandidateResponseDto>();
        CreateMap<CandidateEntity, CandidateLazyResponseDto>();

    }
}