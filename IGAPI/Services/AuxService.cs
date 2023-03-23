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

    public async Task<Response<List<ProjectFullResponse>>> GetProjects()
    {
        var response = new Response<List<ProjectFullResponse>>();

        try
        {
            var projects = await _unitOfWork.ProjectRepository.GetAll();
        
            response.Data = _mapper.Map<List<ProjectFullResponse>>(projects);
            response.Success = true;
            response.Message = "Projects retrieved successfully";
            return response;
        }catch(Exception e)
        {
            response.Data = null;
            response.Success = false;
            response.Message = e.Message;
            return response;
        }
    }

    public async Task<Response<ProjectFullResponse>> UpdateProject(ProjectUpdateRequestDto project)
    {
        var response = new Response<ProjectFullResponse>();
        var projectEntity = _mapper.Map<ProjectEntity>(project);

        if (projectEntity.Name.IsNullOrEmpty() || projectEntity.Name.Trim().Length == 0)
        {
            response.Data = null;
            response.Success = false;
            response.Message = "Project name is required - Update cannot be performed";
            return response;
        }
        
        try
        {
            var l = await _unitOfWork.ProjectRepository.GetByFilter(x => x.Name == projectEntity.Name);
            if (l.Count > 0)
            {
                response.Data = null;
                response.Success = false;
                response.Message = $"Project {projectEntity.Name} already in use - Update cannot be performed";

                return response;
            }

            var et = await _unitOfWork.ProjectRepository.GetById(project.Id);
            if (et == null)
            {
                response.Data = null;
                response.Success = false;
                response.Message = $"Project with id {project.Id} does not exist - Update cannot be performed";

                return response;
            }
            et.Name = projectEntity.Name;
            var updated = await _unitOfWork.ProjectRepository.Update(et);
            await _unitOfWork.SaveChangesAsync();
            response.Data = _mapper.Map<ProjectFullResponse>(updated);
            response.Success = true;
            response.Message = $"Project {projectEntity.Name} updated successfully with id {projectEntity.Id}";
            return response;
        }
        catch (Exception e)
        {
            response.Data = null;
            response.Success = false;
            response.Message = e.Message;
            return response;
        }
    }

    public async Task<Response<ProjectFullResponse>> DeleteProject(int id)
    {
        var response = new Response<ProjectFullResponse>();
        
        try
        {
            var l = await _unitOfWork.ProjectRepository.GetByFilter(x => x.Id == id);
            if (l.Count == 0)
            {
                response.Data = null;
                response.Success = false;
                response.Message = $"Project with id {id} does not exist - Delete cannot be performed";

                return response;
            }
            var deleted = await _unitOfWork.ProjectRepository.Delete(l.First());
            await _unitOfWork.SaveChangesAsync();
            response.Data = _mapper.Map<ProjectFullResponse>(deleted);
            response.Success = true;
            response.Message = $"Project with id {id} deleted successfully";
            return response;
        }
        catch (Exception e)
        {
            response.Data = null;
            response.Success = false;
            response.Message = e.Message;
            return response;
        }
        
    }

    public async Task<Response<ProjectFullResponse>> GetProjectById(int id)
    {
        var response = new Response<ProjectFullResponse>();
        
        try
        {
            var l = await _unitOfWork.ProjectRepository.GetById(id);
            if (l is null)
            {
                response.Data = null;
                response.Success = false;
                response.Message = $"Project with id {id} does not exist";

                return response;
            }
            response.Data = _mapper.Map<ProjectFullResponse>(l);
            response.Success = true;
            response.Message = $"Project with id {id} retrieved successfully";
            return response;
        }
        catch (Exception e)
        {
            response.Data = null;
            response.Success = false;
            response.Message = e.Message;
            return response;
        }
    }
}