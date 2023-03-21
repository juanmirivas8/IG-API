using AutoMapper;
using IGAPI.Dtos.Project;
using IGAPI.Models;
using IGAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace IGAPI.Services;

public class AuxService:IAuxService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public AuxService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    
    public async Task<Response<ProjectFullResponse>> PostProject(ProjectPostRequestDto project)
    {
        var response = new Response<ProjectFullResponse>();
        var projectEntity = _mapper.Map<ProjectEntity>(project);

        if (projectEntity.Name.IsNullOrEmpty() || projectEntity.Name.Trim().Length == 0)
        {
            response.Data = null;
            response.Success = false;
            response.Message = "Project name is required";
            return response;
        }
        
        var l = await _unitOfWork.ProjectRepository.GetByFilter(x => x.Name == projectEntity.Name);
        if (l.Count > 0)
        {
            response.Data = null;
            response.Success = false;
            response.Message = $"Project {projectEntity.Name} already exists";

            return response;
        }

        try
        {
            var inserted = await _unitOfWork.ProjectRepository.Add(projectEntity);
            await _unitOfWork.SaveChangesAsync();
            response.Data = _mapper.Map<ProjectFullResponse>(inserted);
            response.Success = true;
            response.Message = $"Project {projectEntity.Name} created successfully with id {projectEntity.Id}";
            return response;
        }catch(Exception e)
        {
            response.Data = null;
            response.Success = false;
            response.Message = e.Message;
            return response;
        }
    }
    
}