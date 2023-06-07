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
            .ForMember(dest => dest.StatusId, opt => opt.MapFrom(src => src.Status.Id));
        CreateMap<PositionPutDto, PositionEntity>()
            .ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.Project.Id))
            .ForMember(dest => dest.AreaId, opt => opt.MapFrom(src => src.Area.Id))
            .ForMember(dest => dest.RolId, opt => opt.MapFrom(src => src.Rol.Id))
            .ForMember(dest => dest.SubRolId, opt => opt.MapFrom(src => src.SubRol.Id))
            .ForMember(dest => dest.LocalizationId, opt => opt.MapFrom(src => src.Localization.Id))
            .ForMember(dest => dest.StatusId, opt => opt.MapFrom(src => src.Status.Id));
        CreateMap<PositionEntity, PositionResponseDto>()
            .ForMember(dest => dest.Project, opt => opt.MapFrom(src => new ProjectResponseDto { Id = src.ProjectId }))
            .ForMember(dest => dest.Area, opt => opt.MapFrom( src => new AreaResponseDto { Id = src.AreaId }))
            .ForMember(dest => dest.Rol, opt => opt.MapFrom(src => new RolResponseDto { Id = src.RolId }))
            .ForMember(dest => dest.SubRol, opt => opt.MapFrom(src => new SubRolResponseDto { Id = src.SubRolId }))
            .ForMember(dest => dest.Localization, opt => opt.MapFrom(src => new LocalizationResponseDto { Id = src.LocalizationId }))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => new PositionStatusResponseDto { Id = src.StatusId }));
        CreateMap<PositionEntity, PositionLazyResponseDto>()
            .ForMember(dest => dest.Project, opt => opt.MapFrom(src => new ProjectResponseDto { Id = src.ProjectId }))
            .ForMember(dest => dest.Area, opt => opt.MapFrom( src => new AreaResponseDto { Id = src.AreaId }))
            .ForMember(dest => dest.Rol, opt => opt.MapFrom(src => new RolResponseDto { Id = src.RolId }))
            .ForMember(dest => dest.SubRol, opt => opt.MapFrom(src => new SubRolResponseDto { Id = src.SubRolId }))
            .ForMember(dest => dest.Localization, opt => opt.MapFrom(src => new LocalizationResponseDto { Id = src.LocalizationId }))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => new PositionStatusResponseDto { Id = src.StatusId }));
            

        CreateMap<ApplicationPostDto, ApplicationEntity>()
            .ForMember(dest => dest.CandidateId, opt => opt.MapFrom(src => src.Candidate.Id))
            .ForMember(dest => dest.PositionId, opt => opt.MapFrom(src => src.Position.Id))
            .ForMember(dest => dest.StatusId, opt => opt.MapFrom(src => src.Status.Id));
        CreateMap<ApplicationPutDto, ApplicationEntity>()
            .ForMember(dest => dest.CandidateId, opt => opt.MapFrom(src => src.Candidate.Id))
            .ForMember(dest => dest.PositionId, opt => opt.MapFrom(src => src.Position.Id))
            .ForMember(dest => dest.StatusId, opt => opt.MapFrom(src => src.Status.Id));
        CreateMap<ApplicationEntity, ApplicationResponseDto>()
            .ForMember(dest => dest.Candidate, opt => opt.MapFrom(src => new CandidateLazyResponseDto { Id = src.CandidateId }))
            .ForMember(dest => dest.Position, opt => opt.MapFrom(src => new PositionLazyResponseDto { Id = src.PositionId }))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => new ApplicationStatusResponseDto { Id = src.StatusId }));

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
        CreateMap<CandidateEntity, CandidateResponseDto>()
            .ForMember(dest => dest.ContactMethod, opt => opt.MapFrom(src => new ContactMethodResponseDto { Id = src.ContactMethodId }))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => new CandidateStatusResponseDto { Id = src.StatusId }));
        CreateMap<CandidateEntity, CandidateLazyResponseDto>()
            .ForMember(dest => dest.ContactMethod, opt => opt.MapFrom(src => new ContactMethodResponseDto { Id = src.ContactMethodId }))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => new CandidateStatusResponseDto { Id = src.StatusId }));
    }
}