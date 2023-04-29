using AutoMapper;
using IGAPI.Dtos;
using IGAPI.Dtos.Localization;
using IGAPI.Repositories.Interfaces;
using IGAPI.Services.interfaces;

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
}