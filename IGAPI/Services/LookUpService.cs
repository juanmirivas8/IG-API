using AutoMapper;
using IGAPI.Dtos;
using IGAPI.Dtos.ApplicationStatus;
using IGAPI.Dtos.Area;
using IGAPI.Dtos.CandidateStatus;
using IGAPI.Dtos.ContactMethod;
using IGAPI.Dtos.Localization;
using IGAPI.Dtos.PositionStatus;
using IGAPI.Dtos.Project;
using IGAPI.Dtos.Rol;
using IGAPI.Dtos.SubRol;
using IGAPI.Repositories.Interfaces;
using IGAPI.Services.interfaces;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace IGAPI.Services;


public class LookUpService:ILookUpService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public LookUpService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<Response<IEnumerable<LocalizationResponseDto>>> GetAllLocalizations()
    {
        var localizations = await _unitOfWork.LocalizationRepository.GetAll();
        if (localizations.Any())
        {
            return new Response<IEnumerable<LocalizationResponseDto>>
            {
                Data = _mapper.Map<IEnumerable<LocalizationResponseDto>>(localizations),
                Message = "Values returned succesfully",
                Success = true
            };
        }
        else
        {
            return new Response<IEnumerable<LocalizationResponseDto>>
            {
                Message = "Error returning values",
                Success = false
            };
        }
    }

    public async Task<Response<IEnumerable<ObjectWithKey>>> GetAllLookUps()
    {
        var response = new Response<IEnumerable<ObjectWithKey>>
        {
            Data = null,
            Message = "",
            Success = false
        };
        try
        {
            //CREATING TUPLES ENTITYKEY - ENUMERABLE OF ENTITY TO DTO (WITH MAPPER) 
            var areas = new ObjectWithKey { Key = "areas", Value = _mapper.Map<IEnumerable<AreaResponseDto>>(await _unitOfWork.AreaRepository.GetAll())};
            var projects = new ObjectWithKey { Key = "projects", Value = _mapper.Map<IEnumerable<ProjectResponseDto>>(await _unitOfWork.ProjectRepository.GetAll())};
            var rol = new ObjectWithKey { Key = "rol", Value = _mapper.Map<IEnumerable<RolResponseDto>>(await _unitOfWork.RolRepository.GetAll()) };
            var subRol = new ObjectWithKey { Key = "subRol", Value = _mapper.Map<IEnumerable<SubRolResponseDto>>(await _unitOfWork.SubRolRepository.GetAll()) };
            var candidateStatus = new ObjectWithKey { Key = "candidateStatus", Value = _mapper.Map<IEnumerable<CandidateStatusResponseDto>>(await _unitOfWork.CandidateStatusRepository.GetAll()) };
            var positionStatus = new ObjectWithKey { Key = "positionStatus", Value = _mapper.Map<IEnumerable<PositionStatusResponseDto>>(await _unitOfWork.PositionStatusRepository.GetAll()) };
            var applicationStatus = new ObjectWithKey { Key = "applicationStatus", Value = _mapper.Map<IEnumerable<ApplicationStatusResponseDto>>(await _unitOfWork.ApplicationStatusRepository.GetAll()) };
            var localization = new ObjectWithKey { Key = "localization", Value = _mapper.Map<IEnumerable<LocalizationResponseDto>>(await _unitOfWork.LocalizationRepository.GetAll()) };
            var contactMethod= new ObjectWithKey { Key = "contactMethod", Value = _mapper.Map<IEnumerable<ContactMethodResponseDto>>(await _unitOfWork.ContactMethodRepository.GetAll()) };

            List<ObjectWithKey> returnList = new List<ObjectWithKey>();

            returnList.Add(areas);
            returnList.Add(projects);
            returnList.Add(rol);
            returnList.Add(subRol);
            returnList.Add(candidateStatus);
            returnList.Add(positionStatus);
            returnList.Add(applicationStatus);
            returnList.Add(localization);
            returnList.Add(contactMethod);

            response.Message = "All lookUp data loaded succesfully";
            response.Data = returnList;
            response.Success = true;

        }
        catch (Exception ex)
        {
            response.Message = "Error during data extraction";
        }
        

        return response;
    }

}