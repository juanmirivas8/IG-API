using IGAPI.Dtos;
using IGAPI.Dtos.ApplicationStatus;
using IGAPI.Dtos.Candidate;
using Microsoft.AspNetCore.Mvc;
using IGAPI.Dtos.CandidateStatus;
using IGAPI.Dtos.Area;
using IGAPI.Dtos.ContactMethod;
using IGAPI.Dtos.Localization;
using IGAPI.Dtos.PositionStatus;

namespace IGAPI.Controllers.interfaces
{
    public interface IMetaDataController
    {
        // ApplicationStatus
        Task<ActionResult<Response<List<ApplicationStatusResponseDto>>>> GetAllApplicationStatusValues();
        Task<ActionResult<Response<ApplicationStatusResponseDto>>> CreateNewApplicationStatusValue(ApplicationStatusPostDto applicationStatus);
        Task<ActionResult<Response<ApplicationStatusResponseDto>>> UpdateApplicationStatusValue(ApplicationStatusPutDto applicationStatus);
        Task<ActionResult<Response<ApplicationStatusResponseDto>>> DeleteApplicationStatusValue(ApplicationStatusPutDto applicationStatus);

        //Area
        Task<ActionResult<Response<List<AreaResponseDto>>>> GetAllAreaValues();
        Task<ActionResult<Response<AreaResponseDto>>> CreateNewAreaValue(AreaPostDto area);
        Task<ActionResult<Response<AreaResponseDto>>> UpdateAreaValue (AreaPutDto area);
        Task<ActionResult<Response<AreaResponseDto>>> DeleteAreaValue(AreaPutDto area);

        //CandidateStatus
        Task<ActionResult<Response<List<CandidateStatusResponseDto>>>> GetAllCandidateStatusValues();
        Task<ActionResult<Response<CandidateStatusResponseDto>>> CreateNewCandidateStatusValue(CandidateStatusPostDto candidateStatus);
        Task<ActionResult<Response<CandidateStatusResponseDto>>> UpdateCandidateStatusValue(CandidateStatusPutDto candidateStatus);
        Task<ActionResult<Response<CandidateStatusResponseDto>>> DeleteCandidateStatusValue(CandidateStatusPutDto candidateStatus);

        //ContactMethod
        Task<ActionResult<Response<List<ContactMethodResponseDto>>>> GetAllContactMethodValues();
        Task<ActionResult<Response<ContactMethodResponseDto>>> CreateNewContactMethodValue(ContactMethodPostDto contactMethod);
        Task<ActionResult<Response<ContactMethodResponseDto>>> UpdateContactMethodValue(ContactMethodPutDto contactMethod);
        Task<ActionResult<Response<ContactMethodResponseDto>>> DeleteContactMethodValue(ContactMethodPutDto contactMethod);

        //Localization
        Task<ActionResult<Response<List<LocalizationResponseDto>>>> GetAllLocalizationValues();
        Task<ActionResult<Response<LocalizationResponseDto>>> CreateNewLocalizationValue(LocalizationPostDto localization);
        Task<ActionResult<Response<LocalizationResponseDto>>> UpdateLocalizationValue(LocalizationPutDto localization);
        Task<ActionResult<Response<LocalizationResponseDto>>> DeleteLocalizationValue(LocalizationPutDto localization);

        //PositionStatus
        Task<ActionResult<Response<List<PositionStatusResponseDto>>>> GetAllPositionStatusValues();
        Task<ActionResult<Response<PositionStatusResponseDto>>> CreateNewPositionStatusValue(PositionStatusPostDto positionStatus);
        Task<ActionResult<Response<PositionStatusResponseDto>>> UpdatePositionStatusValue()

    }
}
