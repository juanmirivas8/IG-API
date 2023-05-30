using AutoMapper;
using IGAPI.Repositories.Interfaces;

namespace IGAPI.Services;

public abstract class Service
{
    protected readonly IUnitOfWork _unitOfWork;
    protected readonly IMapper _mapper;
    
    protected Service(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
}