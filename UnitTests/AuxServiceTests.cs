using System.Linq.Expressions;
using AutoMapper;
using IGAPI;
using IGAPI.Dtos.Area;
using IGAPI.Dtos.Project;
using IGAPI.Models;
using IGAPI.Repositories;
using IGAPI.Repositories.Interfaces;
using IGAPI.Services;
using Moq;

namespace UnitTests;

public class AuxServiceTests
{
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void PostProject_InvalidProjectName_ReturnsBadResponse(string projectName)
    {
        // Arrange
        var mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new AutoMapperProfile())));
        var projectRepository = new Mock<IProjectRepository>();
        var unitOfWork = new UnitOfWork(projectRepository.Object, null);
        var auxService = new AuxService(unitOfWork, mapper);

        var project = new ProjectPostRequestDto
        {
            Name = projectName,
        };
        // Act
        var response = auxService.PostProject(project);

        // Assert
        Assert.False(response.Result.Success);
        Assert.Null(response.Result.Data);
        Assert.Equal("Project name is required", response.Result.Message);
    }

    [Theory]
    [InlineData("Project 1")]
    public void PostProject_ExistingProjectName_ReturnsBadResponse(string projectName)
    {
        // Arrange
        var mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new AutoMapperProfile())));
        var projectRepository = new Mock<IProjectRepository>();
        projectRepository.Setup(x => x.GetByFilter(It.IsAny<Expression<Func<ProjectEntity, bool>>>()))
            .ReturnsAsync((Expression<Func<ProjectEntity, bool>> filter) =>
                new List<ProjectEntity> { new ProjectEntity { Name = projectName } });

        var unitOfWork = new UnitOfWork(projectRepository.Object, null);
        var auxService = new AuxService(unitOfWork, mapper);

        var project = new ProjectPostRequestDto
        {
            Name = projectName,
        };
        // Act
        var response = auxService.PostProject(project);

        // Assert
        Assert.False(response.Result.Success);
        Assert.Null(response.Result.Data);
        Assert.Equal($"Project {projectName} already exists", response.Result.Message);
        projectRepository.Verify(x => x.GetByFilter(It.IsAny<Expression<Func<ProjectEntity, bool>>>()), Times.Once);
    }

    [Theory]
    [InlineData("Project 1", new[] { "Area 1", "Area 2" })]
    public void PostProject_ValidProject_ReturnsGoodResponse(string nameProject, String[] areas)
    {
        // Arrange
        var areasDto = areas.Select(x => new AreaPostRequestDto { Name = x }).ToList();
        var projectRequest = new ProjectPostRequestDto
        {
            Name = nameProject,
            Areas = areasDto,
        };
        var mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new AutoMapperProfile())));
        var projectRepository = new Mock<IProjectRepository>();
        projectRepository.Setup(pr => pr.Add(It.IsAny<ProjectEntity>())).ReturnsAsync((ProjectEntity p) =>
        {
            
            int id = 1;
            p.Name = p.Name;
            p.Id = 1;
            p.Areas = p.Areas;
            
            p.Areas.ForEach(x => x.ProjectId = 1);
            p.Areas.ForEach(x => x.Id = id++);
            return p;
        });
        projectRepository.Setup(x => x.GetByFilter(It.IsAny<Expression<Func<ProjectEntity, bool>>>()))
            .ReturnsAsync((Expression<Func<ProjectEntity, bool>> filter) => new ());
           
        var unitOfWork = new Mock<IUnitOfWork>();
        unitOfWork.Setup(uow => uow.ProjectRepository).Returns(projectRepository.Object);
        unitOfWork.Setup(uow => uow.SaveChangesAsync()).ReturnsAsync(1);
        var auxService = new AuxService(unitOfWork.Object, mapper);
        
        
        
        // Act
        var response = auxService.PostProject(projectRequest);
        // Assert
        projectRepository.Verify(x => x.Add(It.IsAny<ProjectEntity>()), Times.Once);
        projectRepository.Verify(x => x.GetByFilter(It.IsAny<Expression<Func<ProjectEntity, bool>>>()), Times.Once);
        unitOfWork.Verify(x => x.SaveChangesAsync(), Times.Once);
        Assert.True(response.Result.Success);
        Assert.NotNull(response.Result.Data);
    }
    
    [Theory]
    
}